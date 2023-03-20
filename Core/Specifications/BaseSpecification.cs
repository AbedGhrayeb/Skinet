
using System.Linq.Expressions;

namespace Core.Specifications
{
    public class BaseSpecification<T> : ISpecification<T> where T:class
    {
        public BaseSpecification(){}

        public BaseSpecification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
            
        }
        public Expression<Func<T, bool>> Criteria {get;}

        public List<Expression<Func<T, object>>> Includes {get;}=new();

        protected void AddInclude(Expression<Func<T,object>> expressionInclude)
        {
            Includes.Add(expressionInclude);
        }
    }
}