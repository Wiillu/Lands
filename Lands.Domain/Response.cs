namespace Lands.Domain
{
    public class Response
    {
        //Respuesta de servicios
        public bool IsSuccess
        {
            get;
            set;
        }
        public string Message
        {
            get;
            set;
        }

        public object Result
        {
            get;
            set;
        }
    }
}
