using System.Threading.Tasks;

namespace myInvoices
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var sendInvoice = new SendInvoiceExample();
            await sendInvoice.SendInvoiceToYpahes("username", "password",true);
        }
    }
}
