﻿namespace HomeTaskFirstApiApp.Dtos
{
    public class CreateProductDto
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int Price { get; set; }
        public int Count { get; set; }
    }
}
