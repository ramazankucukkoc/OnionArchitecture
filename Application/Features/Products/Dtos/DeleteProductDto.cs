﻿namespace Application.Features.Products.Dtos
{
    public class DeleteProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CategoryId { get; set; }
    }
}
