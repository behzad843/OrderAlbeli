using AutoFixture;
using Microsoft.Extensions.DependencyInjection;
using OrderManagement.Contrast;
using OrderManagement.Model.Models;

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
            using (TestEnvInjection container = new TestEnvInjection())
            {
                var orderService = container.GetService().GetRequiredService<IOrderService>();

                // Act
                double realBandWidth = 293.8;
                var testData = SeedOrderCreateData();

                // Act
                var result = await orderService.CalcRequiredBinWidth(testData);

                // Assert
                Assert.Equal(realBandWidth, result, 2);
            }

        }

        [Fact]
        public async Task Calc_Product_Size()
        {
            // Arrange

            using (TestEnvInjection container = new TestEnvInjection())
            {
                var productService = container.GetService().GetRequiredService<IProductService>();

                // Act
                double result = await productService.CalcProductSize(Model.Enum.ProductTypeEnum.mug, 5);

                // Assert
                Assert.Equal(188, result, 1);
            }
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