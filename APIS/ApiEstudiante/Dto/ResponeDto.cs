namespace ApiEstudiante.Dto
{
    public class ResponeDto
    {
        public bool IsSucceed { get; set; }
        public object? Result { get; set; }
        public string DisplayMessage { get; set; } = "";
    }
}
