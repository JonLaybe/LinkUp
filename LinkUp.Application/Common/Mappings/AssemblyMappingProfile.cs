using AutoMapper;
using System;
using System.Reflection;

namespace LinkUp.Application.Common.Mappings
{
    public class AssemblyMappingProfile : Profile
    {
        public AssemblyMappingProfile(Assembly assembly)
        {
            ApplyMappingsFromAssembly(assembly);
        }

        private void ApplyMappingsFromAssembly(Assembly assembly)
        {
            Type[] typesAssembly = assembly.GetExportedTypes(); // Все типы данных в сборке
            var types = typesAssembly.Where(type => type.GetInterfaces().Any(
                i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapWith<>))).ToList();

            foreach(var type in types)
            {
                var instance = Activator.CreateInstance(type); // Создает объект экземпляра зданного типа
                /*Ищет метод с именем "Mapping" в типе type.
                 * Полученная информация о методе сохраняется в переменной methodInfo.
                 * Если метод не найден, то methodInfo будет равен null.*/
                var methodInfo = type.GetMethod("Mapping");
                // Вызывает метод или конструктор, представленный текущим экземпляром, на основе указанных параметров.
                methodInfo?.Invoke(instance, new object[] { this });
            }
        }
    }
}
