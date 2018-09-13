using BoomiSharp.Dtos.BoomiObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace BoomiSharp.Query.ExpressionBuilders
{
    public class ComponentEnvironmentAttachmentExpressionBuilder : BaseExpressionBuilder<ComponentEnvironmentAttachment>
    {
        public PredicateExpressionBuilder<string> EnvironmentId => new PredicateExpressionBuilder<string>();
        public PredicateExpressionBuilder<string> ComponentId => new PredicateExpressionBuilder<string>();
        public PredicateExpressionBuilder<ComponentType> ComponentType => new PredicateExpressionBuilder<ComponentType>();
    }
}
