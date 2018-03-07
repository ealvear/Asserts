var tiempo_start : float = 0.0; //Los segundos por los quales comienza i la variable que utilizaremos para que vaya contando segundos.
var tiempo_end : float = 0.0; //Segundos que queremos que pasen para que cambie de escena.
var escena : String; //Esta es la escena a la que irá quando pasen los segundos que hemos puesto.
function Update (){
    tiempo_start += Time.deltaTime;//Función para que la variable tiempo_start vaya contando segundos.
    if (tiempo_start>=tiempo_end) //Si pasan los segundos que hemos puesto antes...
	{
        Application.LoadLevel(escena); //Iremos a la escena que hemos puesto anteriormente.
    }



}