using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Caching;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.Autofac.Caching
{
    // Her seferinde veriyi veritabanından çekmek yerine cache ederek burdan çekebiliriz.
    public class CacheAspect : MethodInterception
    {
        int _duration;
        ICacheManager _cacheManager;

        public CacheAspect(int duration = 60)
        {
            _duration = duration;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>(); // Redis eklemek için burda değişikliğe gerek yoktur.Redis klasör olurturmak ve coremodule eklemek.
        }

        public override void Intercept(IInvocation invocation)
        {
            //invocation(metot) || ReflectedType.FullName ( namespace ismini alır.) || Method.Name (metot ismini alır.)
            //Northwind.Business.IProductService.GetAll();
            var methodName = string.Format($"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}");
            var arguments = invocation.Arguments.ToList(); // Metodun parametrelerini listeye çevirir.
            var key = $"{methodName}({string.Join(",", arguments.Select(x => x?.ToString() ?? "<Null>"))})"; // varsa parametleri ekler yoksa null atar. || join işlemi ile her parametre arasına "," eklemek için. 
            if (_cacheManager.IsAdd(key)) // cache işleminin kontrol eder.
            {
                invocation.ReturnValue = _cacheManager.Get(key); // Eğer cache sisteminde istenilen bilgi varsa veritabına gitmeden çalışır.
                return;
            }
            invocation.Proceed(); // Eğer cache içerisinde istenilen veri yoksa veri tabanına ulaşır.
            _cacheManager.Add(key, invocation.ReturnValue, _duration); // bu kısımda veritabanından alınan veri cache eklenir.

        }
    }
}
