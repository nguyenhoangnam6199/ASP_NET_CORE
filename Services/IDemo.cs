using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Buoi14_ADONET.Services
{
    public interface IDemoTrasient
    {
        Guid GetGuid();
    }

    public interface IDemoSingleton
    {
        Guid GetGuid();
    }

    public interface IDemoScoped
    {
        Guid GetGuid();
    }


    public class DemoSingleton : IDemoSingleton
    {
        public Guid GetGuid()
        {
            return Guid.NewGuid();
        }
    }

    public class DemoScoped : IDemoScoped
    {
        public Guid GetGuid()
        {
            return Guid.NewGuid();
        }
    }

    public class DemoTrasient : IDemoTrasient
    {
        public Guid GetGuid()
        {
            return Guid.NewGuid();
        }
    }

    public class DemoAll : IDemoScoped, IDemoSingleton, IDemoTrasient
    {
        private Guid _guid;
        public DemoAll()
        {
            _guid = Guid.NewGuid();
        }
        public Guid GetGuid()
        {
            return _guid;
        }
    }
}
