using Microsoft.AspNetCore.Components.Forms;
using QuickShop.Shared.Models;

namespace QuickShop.Client.Imagehelper
{
    public class ImageHelper
    {
       public async Task HandleImageUpload(InputFileChangeEventArgs e, String ImageUploadMessage, Product product)
        {
            if (e.File.Name.ToLower().Contains(".png"))
            {
                var format = "image/png";
                var resizeImage = await e.File.RequestImageFileAsync(format, 300, 300);
                var buffer = new byte[resizeImage.Size];
                await resizeImage.OpenReadStream().ReadAsync(buffer);
                var imagedata = $"data:{format};base64,{Convert.ToBase64String(buffer)}";
                ImageUploadMessage = "";
                product.Image = imagedata;
                imagedata = "";
                return;
            }
            ImageUploadMessage = "PNG necesario";
            return;
        }
    }
}
