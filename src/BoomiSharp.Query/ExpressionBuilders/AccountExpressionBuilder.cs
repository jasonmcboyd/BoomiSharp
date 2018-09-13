using BoomiSharp.Dtos.BoomiObjects;
using System;

namespace BoomiSharp.Query.ExpressionBuilders
{
    public class AccountExpressionBuilder : BaseExpressionBuilder<Account>
    {
        public PredicateExpressionBuilder<string> AccountId => new PredicateExpressionBuilder<string>();
        public PredicateExpressionBuilder<string> Name => new PredicateExpressionBuilder<string>();
        public PredicateExpressionBuilder<DateTime> DateCreated => new PredicateExpressionBuilder<DateTime>();
        public PredicateExpressionBuilder<DateTime> ExpirationDate => new PredicateExpressionBuilder<DateTime>();
        public PredicateExpressionBuilder<AccountStatus> Status => new PredicateExpressionBuilder<AccountStatus>();
        public PredicateExpressionBuilder<bool> WidgetAccount => new PredicateExpressionBuilder<bool>();
    }
}
