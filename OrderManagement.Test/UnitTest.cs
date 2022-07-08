using AutoFixture;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NSubstitute;
using OrderManagement.Contrast;
using OrderManagement.Model.Entities;
using OrderManagement.Model.Models;
using OrderManagement.Repository.GenericRepository;
using OrderManagement.Repository.UnitOfWork;
using OrderManagement.Services;
using OrderManagement.UI.Controllers;

namespace OrderManagement.Test
{
    public class UnitTest
    {
        private readonly Random random;
        private Fixture fixture;

        public UnitTest()
        {
            random = new Random();
            fixture = new Fixture();
        }

        [Fact]
        public async Task Calculate_Required_BandWidth()
        {
            // Arrange
            var unitMock = Substitute.For<IUnitOfWork>();
            var genericMock = Substitute.For<IGenericRepository<Order>>();
            var orderItemMock = Substitute.For<IGenericRepository<OrderItem>>();
            var iProductMock = Substitute.For<IProductService>();
            var orderService = new OrderService(unitMock, genericMock, orderItemMock, iProductMock);
            double realBandWidth = 293.8;
            var testData = SeedOrderCreateData();

            // Act
            var result = await orderService.CalcRequiredBinWidth(testData);

            // Assert
            Assert.Equal(realBandWidth, result,2);
        }

        [Fact]
        public async Task Calc_Product_Size()
        {
            // Arrange
            var unitMock = Substitute.For<IUnitOfWork>();
            var genericMock = Substitute.For<IGenericRepository<Product>>();
            var productService = new ProductService(unitMock, genericMock);

            // Act
            double result = await productService.CalcProductSize(Model.Enum.ProductTypeEnum.mug,5);

            // Assert
            Assert.Equal(188, result, 1);
        }

        private OrderListCreateRequest SeedOrderCreateData()
        {
            List<OrderCreateRequest> orderListTest = new List<OrderCreateRequest>();
            OrderCreateRequest orderTestMug = new OrderCreateRequest()
            {
                ProductId = Model.Enum.ProductTypeEnum.mug,
                quanity = 5
            };
            OrderCreateRequest orderTestPhotoBook = new OrderCreateRequest()
            {
                ProductId = Model.Enum.ProductTypeEnum.photoBook,
                quanity = 1
            };
            OrderCreateRequest orderTestCalendar = new OrderCreateRequest()
            {
                ProductId = Model.Enum.ProductTypeEnum.calendar, 
                quanity = 2
            };
            OrderCreateRequest orderTestCanvas = new OrderCreateRequest()
            {
                ProductId = Model.Enum.ProductTypeEnum.canvas,
                quanity = 3
            };
            OrderCreateRequest orderTestCards = new OrderCreateRequest()
            {
                ProductId = Model.Enum.ProductTypeEnum.cards,
                quanity = 4
            };

            orderListTest.Add(orderTestMug);
            orderListTest.Add(orderTestPhotoBook);
            orderListTest.Add(orderTestCalendar);
            orderListTest.Add(orderTestCanvas);
            orderListTest.Add(orderTestCards);

            return new OrderListCreateRequest()
            {
                orderRequest = orderListTest
            };
        }
    }
}