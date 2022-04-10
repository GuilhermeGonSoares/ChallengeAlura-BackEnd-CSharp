using System.Text.RegularExpressions;
using ChallengeAluraBackEnd.Models;

namespace ChallengeAluraBackEnd.Services
{
    public class ValidarVideo
    {
        
        public static void validar(Video videoASerValidado)
        {   
            var titulo = videoASerValidado.Titulo.Trim();
            var descricao = videoASerValidado.Descricao.Trim();
            var url = videoASerValidado.Url.Trim();
            
            string pattern = @"(https?:\/\/)[^$#\s].[^\s]*";
            Regex urlRegex = new Regex(pattern);
            var match = urlRegex.Match(url);
            
            if(titulo == string.Empty)
                throw new ArgumentException("O título do vídeo não pode ser vazia!") ;
            if(descricao == string.Empty)
                throw new ArgumentException("A descrição do vídeo não pode ser vazia!") ;
            if(url == string.Empty)
                throw new ArgumentException("A URL não pode ser vazia!") ;
            if(!match.Success)
                throw new ArgumentException("A URL não é válida! Verifique se ela segue " +
                "o seguinte exemplo: 'http(s)://...") ;
        }
    }
}