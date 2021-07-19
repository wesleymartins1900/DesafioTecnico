using System.Text;

namespace Domain
{
    public class BaseDto
    {
        public BaseDto()
        {
            Erros = new StringBuilder();
        }

        public StringBuilder Erros { get; set; }
        public bool IsValid { get; set; }
    }
}