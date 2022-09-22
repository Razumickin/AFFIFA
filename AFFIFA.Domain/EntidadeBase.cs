
namespace AFFIFA.Domain
{
    public abstract class EntidadeBase
    {
        public const int Status200OK = 200;
        public const int Status201Created = 201;
        public const int Status404NotFound = 404;
        public const int Status400BadRequest = 400;
        public const int Status500InternalServerError = 500;

        public class Resposta
        {
            public int Status { get; set; }
            public Object Objeto { get; set; }
            public Resposta(int status, Object objeto)
            {
                switch (status)
                {
                    case Status200OK: Status = Status200OK; break;
                    case Status201Created: Status = Status201Created; break;
                    case Status404NotFound: Status = Status404NotFound; break;
                    case Status400BadRequest: Status = Status400BadRequest; break;
                    case Status500InternalServerError: Status = Status500InternalServerError; break;
                    default: Status = 0; break;
                }

                Objeto = objeto;
            }
        }        
    }
}
