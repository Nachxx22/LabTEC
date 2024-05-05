public class devoactivoTemplate{ 
    //class template para realizar las devoluciones
    //de activos con o sin averia.
    public int id { get; set; } //id del activo
    public string nomActivo { get; set; }
    public string contrasena { get; set; }
    public bool averia { get; set; }
    public string desAveria { get; set; }
}