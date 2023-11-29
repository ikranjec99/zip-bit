namespace ZipBit.API.Extensions
{
    public static class MiddlewareExtensions
    {
        public static void ConfigureMiddlewares(this WebApplication app)
        {
            app.UseDefaultFiles()
            .UseStaticFiles()
            .UseSwagger()
            .UseSwaggerUI()
            .UseHttpsRedirection()
            .UseAuthorization();
        }
    }
}
