using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception("Bu bir Validator sınıfı değil.");
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType); //reflection. çalışma anında new'leme işlemi yapıyoruz.
            var entityType = _validatorType.BaseType.GetGenericArguments()[0]; //ProductValidatorun base type'ını bul. Onun generic argumanlarından ilkini bul. ilgili validatorun çalışma tipini bul
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);//aspectin çalıştırıldığı metodun parametrelerini bul.
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity); //metodun tüm parametrelerinde tek tek ValidationTool'u çalıştır.
            }
        }
    }
}
