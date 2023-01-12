using FluentValidation;

namespace poc_blazor.Shared.DTO
{
    public static class ProductDTO
    {
        public class Create
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Image { get; set; }
            public double Price { get; set; }
            public string Description { get; set; }

            public class Validator: AbstractValidator<Create>
            {
                public Validator()
                {
                    RuleFor(p => p.Name).NotEmpty();
                    RuleFor(p => p.Image).NotEmpty();
                    RuleFor(p => p.Price).NotEmpty().InclusiveBetween(0, 10000);
                    RuleFor(p => p.Description).NotEmpty();
                }
            }
        }   
    }
}
