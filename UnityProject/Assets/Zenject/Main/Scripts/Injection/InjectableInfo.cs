using System;
using System.Linq;

namespace Zenject
{
    // An injectable is a field or property with [Inject] attribute
    // Or a constructor parameter
    internal class InjectableInfo
    {
        public readonly bool Optional;
        public readonly string Identifier;

        // The field name or property name from source code
        public readonly string MemberName;
        // The field type or property type from source code
        public readonly Type MemberType;

        public readonly Type ObjectType;

        // Null for constructor declared dependencies
        public readonly Action<object, object> Setter;

        public InjectableInfo(
            bool optional, string identifier, string memberName,
            Type memberType, Type objectType, Action<object, object> setter)
        {
            Optional = optional;
            Setter = setter;
            ObjectType = objectType;
            MemberType = memberType;
            MemberName = memberName;
            Identifier = identifier;
        }

        public InjectContext CreateInjectContext(
            DiContainer container, InjectContext currentContext, object targetInstance)
        {
            return new InjectContext(
                container, MemberType, Identifier, Optional,
                ObjectType, targetInstance, MemberName, currentContext);
        }
    }
}
