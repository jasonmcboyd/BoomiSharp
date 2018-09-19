using BoomiSharp.Dtos.BoomiObjects;
using BoomiSharp.Http;
using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;

namespace BoomiSharp.Rx
{
    public class BoomiRxClient : IDisposable
    {
        public BoomiRxClient(
            string api,
            string username,
            string password) : this(new Uri(api), username, password)
        {
        }

        public BoomiRxClient(
            Uri api,
            string username,
            string password)
        {
            this._WhenApiCallInvoked = this._JobQueue.Zip(this._Queue, (job, q) => $"{job}_{q}");

            // When an API request is sent wait one second and then add a unit to the queue.
            this
            ._WhenApiCallInvoked
            .Delay(TimeSpan.FromSeconds(1))
            .Subscribe(onNext: _ =>
                {
                    this._Queue.OnNext(this.counter);
                    this.counter++;
                });

            // Fill the queue.
            for (int i = 0; i < BoomiRxClient._ApiLimit; i++)
            {
                this._Queue.OnNext(this.counter);
                this.counter++;
            }
            
            if (!api.AbsoluteUri.EndsWith("/"))
            {
                api = new Uri($"{api.AbsoluteUri}/");
            }

            this._Client = new HttpClient()
            {
                BaseAddress = api
            };
            
            this._Client.DefaultRequestHeaders.Add("Accept", "application/json");
            this._Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("BASIC", Convert.ToBase64String(Encoding.UTF8.GetBytes($"{username}:{password}")));
        }

        private int counter = 0;

        private readonly HttpClient _Client;

        #region Boomi Objects

        //public Task<T> GetBoomiObjectAsync<T>(Guid id) 
        //    where T : IBoomiObject, ICanGet
        //{
        //    return this._Client.GetAsync<T>(BoomiObjectUrlMapper.GetObjectUrl<T>(id));
        //}

        //public Task<T> GetBoomiObjectAsync<T>(string id)
        //    where T : IBoomiObject, ICanGet
        //{
        //    //var task = this._Client.GetAsync<T>(BoomiObjectUrlMapper.GetObjectUrl<T>(id));
        //    return this.EnqueueJob(() => this._Client.GetAsync<T>(BoomiObjectUrlMapper.GetObjectUrl<T>(id)));
        //}

        #endregion

        #region IObservable

        private const int _ApiLimit = 1;

        public readonly Subject<int> _Queue = new Subject<int>();
        public readonly Subject<Guid> _JobQueue = new Subject<Guid>();
        public readonly IObservable<string> _WhenApiCallInvoked;
        
        private async Task<T> EnqueueJob<T>(Func<Task<T>> job)
        {
            var jobId = Guid.NewGuid();
            var obs = this._WhenApiCallInvoked.Replay();
            using (obs.Connect())
            {
                this._JobQueue.OnNext(jobId);
                var temp = await obs.Where(x => x.StartsWith(jobId.ToString())).Take(1);
                Console.WriteLine($"awaited: {temp}");
                //var result = await job();
                await Task.Delay(1000);
                
                //return result;
                return default(T);
            }
        }

        public IObservable<Unit> WhenApiCallInvoked()
        {
            return this._WhenApiCallInvoked.Select(x => Unit.Default);
        }

        #endregion

        #region IDisposable Implementation

        // See http://msdn.microsoft.com/en-us/library/b1yfkh5e(v=vs.110).aspx for the proper
        // implementation of the Dispose pattern.

        private readonly object _DisposeLock = new object();

        private bool _IsDisposed = false;
        /// <summary>
        /// Gets a boolean value that indicates if the object has been disposed.
        /// </summary>
        public bool IsDisposed
        {
            get { return this._IsDisposed; }
            private set { this._IsDisposed = value; }
        }

        protected virtual void Dispose(bool disposing)
        {
            // If this object has already been disposed then exit without doing anything.
            if (this.IsDisposed)
            {
                return;
            }

            // Lock the critical section to ensure that more than one thread cannot attempt to 
            // dispose the object at the same time.
            lock (this._DisposeLock)
            {
                // Check IsDisposed again in case more than one thread got to the lock.
                // This ensures that only the first thread through the lock will execute the 
                // critical section and that any other threads will exit without doing anything.
                if (this.IsDisposed)
                {
                    return;
                }

                // Dispose of the object.
                if (disposing)
                {
                    // Dispose of resources here.
                    this._Client?.Dispose();
                    this._JobQueue?.Dispose();
                }

                // Set IsDisposed to true.
                this.IsDisposed = true;
            }
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

        
    }
}
