using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebExperiment
{
    public class Resource
    {
        private readonly string _name;
        private readonly ICollection<Resource> _children;
//        private readonly Dictionary<string, IMethod> _methods;
        
//        public Resource(string name, ICollection<Resource> children, Dictionary<string, IMethod> methods)
//        {
//            _name = name;
//            _children = children;
//            _methods = methods;
//        }

        private bool HandleSelf(string methodType)
        {
            throw new NotImplementedException();
//            return _methods.TryGetValue(methodType, out var m) && m.Handle();
        }
        
        public bool Handle(string methodType, ICollection<string> pathEntries)
        {
            var firstEntry = pathEntries.First();
            var otherEntries = pathEntries.Skip(1).ToArray();
            
            if (firstEntry != _name)
                return false;

            return otherEntries.Any()
                ? _children.Any(c => c.Handle(methodType, otherEntries))
                : HandleSelf(methodType);
        }
    }
}