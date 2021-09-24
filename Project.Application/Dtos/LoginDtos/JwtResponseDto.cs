namespace Project.Application.Dtos.LoginDtos
{
    public class JwtResponseDto
    {
        public string Token { get; set; }
        public bool IsSuccess { get; set; }

        public static JwtResponseDto Faild()
        {
            return new JwtResponseDto
            {
                Token = null,
                IsSuccess = false
            };
        }
    }
}
