using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Threading.Tasks;
using System.Threading.Tasks;

namespace BoomiSharp.Rx
{
    public static class BoomiReactiveExtensions
    {
        public static IObservable<T> BufferApiCalls<T>(this IEnumerable<Task<T>> source)
        {
            return
                Observable
                .Return(default(long))
                .Concat(Observable.Interval(TimeSpan.FromMilliseconds(1100)))
                .Zip(
                    source.Buffer(5),
                    (_, x) => x.ToObservable().SelectMany(y => y.ToObservable()))
                .SelectMany(x => x);
        }
    }
}
