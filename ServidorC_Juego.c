#include <string.h>
#include <unistd.h>
#include <stdlib.h>
#include <sys/types.h>
#include <sys/socket.h>
#include <netinet/in.h>
#include <stdio.h>
#include <pthread.h>
#include <mysql.h>
#include <string.h>
#include <stdlib.h>
#include <stdio.h>

int consultaSignUp(char userName[], char password[], char mensajeSignUp[]){
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	MYSQL *conn;
	int err,n;
	char ID[10];
	
	char consulta [80];
	//Creamos una conexion al servidor MYSQL 
	conn = mysql_init(NULL);
	
	if (conn==NULL) {
		printf ("Error al crear la conexion: %u %s\n",
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	conn = mysql_real_connect (conn, "localhost","root", "mysql", "Juego",0, NULL, 0);
	if (conn==NULL) {
		printf ("Error al inicializar la conexion: %u %s\n",
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	mysql_query(conn, "use Juego;");
	
	strcpy (consulta, "select exists(SELECT Jugador.userName FROM Jugador WHERE Jugador.userName = '");
	strcat (consulta, userName); 
	strcat (consulta, "');");
	mysql_query(conn, consulta);
	resultado = mysql_store_result (conn);
	row = mysql_fetch_row (resultado);
	
	if (atoi(row[0]) == 0)
	{
		mysql_query(conn,"SELECT COUNT(ID) FROM Jugador");
		resultado = mysql_store_result (conn);
		row = mysql_fetch_row (resultado);
		n = atoi(row[0]) + 1;
		sprintf(ID,"%d",n);
		
		strcpy (consulta, "INSERT INTO Jugador VALUES ('");
		strcat (consulta, ID); 
		strcat (consulta, "','");
		strcat (consulta, userName); 
		strcat (consulta, "','");
		strcat (consulta, password); 
		strcat (consulta, "');");
		
		printf("consulta = %s\n", consulta);
		// Ahora ya podemos realizar la insercion 
		err = mysql_query(conn, consulta);
		if (err!=0) {
			printf ("Error al introducir datos la base %u %s\n", 
					mysql_errno(conn), mysql_error(conn));
			exit (1);
		}
		strcpy(mensajeSignUp,"Se ha creado su usuario correctamente.");
	}
	else{
		strcpy(mensajeSignUp,"El usuario ya existe, elija otro username.");
	}
	// cerrar la conexion con el servidor MYSQL 
	mysql_close (conn);
	return 0;
}

int consultaLogIn(char userName[], char password[], char mensajeLogIn[]){
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	MYSQL *conn;
	int err,n;
	char ID[10];
	
	char consulta [800];
	//Creamos una conexion al servidor MYSQL 
	conn = mysql_init(NULL);
	
	if (conn==NULL) {
		printf ("Error al crear la conexion: %u %s\n",
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	conn = mysql_real_connect (conn, "localhost","root", "mysql", "Juego",0, NULL, 0);
	if (conn==NULL) {
		printf ("Error al inicializar la conexion: %u %s\n",
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	mysql_query(conn, "use Juego;");
	
	strcpy (consulta, "select exists(SELECT Jugador.userName FROM Jugador WHERE Jugador.userName = '");
	strcat (consulta, userName); 
	strcat (consulta, "');");
	mysql_query(conn, consulta);
	resultado = mysql_store_result (conn);
	row = mysql_fetch_row (resultado);
	
	if (atoi(row[0]) == 1)
	{
		strcpy (consulta, "select exists(SELECT Jugador.pssword FROM Jugador WHERE Jugador.userName = '");
		strcat (consulta, userName); 
		strcat (consulta, "' AND Jugador.pssword = '");
		strcat (consulta, password); 
		strcat (consulta, "');");
		mysql_query(conn, consulta);
		resultado = mysql_store_result (conn);
		row = mysql_fetch_row (resultado);
		
		if (atoi(row[0]) == 1)
		{
			// Ahora ya podemos realizar la insercion 
			err = mysql_query(conn, consulta);
			if (err!=0) {
				printf ("Error al introducir datos la base %u %s\n", 
						mysql_errno(conn), mysql_error(conn));
				exit (1);
			}
			strcpy(mensajeLogIn,"Se ha iniciado sesion correctamente.");
		}
		else{
			strcpy(mensajeLogIn,"La contrasenya que ha introducido es incorrecta.");
		}
	}
	else{
		strcpy(mensajeLogIn,"El usuario no existe, cree un usuario.");
	}
	// cerrar la conexion con el servidor MYSQL 
	mysql_close (conn);
	return 0;
}

int consulta1(char nombre[])
{
	MYSQL *conn;
	int err;
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	
	conn = mysql_init(NULL);
	if (conn==NULL) {
		printf ("Error en conexion: %u %s\n", mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	conn = mysql_real_connect (conn, "localhost","root", "mysql", "Juego", 0, NULL, 0);
	if (conn==NULL){
		printf ("Error en conexion: %u %s\n", mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	mysql_query(conn, "USE Juego;");
	
	char consulta [800];
	strcpy (consulta,"SELECT SUM(PartidasJugadores.puntuacion) FROM Jugador,Partida,PartidasJugadores WHERE Jugador.userName = '");
	strcat (consulta, nombre);
	strcat (consulta,"' AND Partida.ID = PartidasJugadores.ID_Partida AND PartidasJugadores.ID_jugador = Jugador.ID");
	mysql_query (conn, consulta);
	
	resultado = mysql_store_result (conn);
	row = mysql_fetch_row (resultado);
	
	if (row == NULL)
		printf ("No se han obtenido datos en la consulta\n");
	
	int puntosTotales = atoi(row[0]);
	mysql_close (conn);
	return puntosTotales;
}

int consulta2(char nombre[],char puntuaciones[])
{
	MYSQL *conn;
	int err;
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	
	conn = mysql_init(NULL);
	if (conn==NULL) {
		printf ("Error en conexion: %u %s\n", mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	conn = mysql_real_connect (conn, "localhost","root", "mysql", "Juego", 0, NULL, 0);
	if (conn==NULL){
		printf ("Error en conexion: %u %s\n", mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	mysql_query(conn, "USE Juego;");
	
	char consulta [800];
	strcpy (consulta,"SELECT PartidasJugadores.Puntuacion FROM Jugador,Partida,PartidasJugadores WHERE Jugador.userName = '");
	strcat (consulta, nombre);
	strcat (consulta,"' AND Partida.ID = PartidasJugadores.ID_Partida AND PartidasJugadores.ID_jugador = Jugador.ID");
	mysql_query (conn, consulta);
	
	resultado = mysql_store_result (conn);
	row = mysql_fetch_row (resultado);
	
	if (row == NULL)
		printf ("Ha habido un error en la consulta de datos \n");
	else
	{
		int i = 0;
		strcpy(puntuaciones,"");
		while (row !=NULL) {
			strcat (puntuaciones, row[0]);
			strcat (puntuaciones, "/");
			row = mysql_fetch_row (resultado);
			i++;
		}
	}
	mysql_close (conn);
	return 0;
}

int consulta3(char partidaID[],char ganador[])
{
	MYSQL *conn;
	int err;
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	
	conn = mysql_init(NULL);
	if (conn==NULL) {
		printf ("Error en conexion: %u %s\n", mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	conn = mysql_real_connect (conn, "localhost","root", "mysql", "Juego", 0, NULL, 0);
	if (conn==NULL){
		printf ("Error en conexion: %u %s\n", mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	mysql_query(conn, "USE Juego;");
	
	char consulta [800];
	strcpy (consulta,"SELECT Partida.ganador FROM Partida WHERE Partida.ID = '");
	strcat (consulta, partidaID);
	strcat (consulta,"';");
	mysql_query (conn, consulta); 
	
	resultado = mysql_store_result (conn);
	row = mysql_fetch_row (resultado);
	
	if (row == NULL)
		printf ("Ha habido un error en la consulta de datos \n");
	else{
		strcpy(ganador,row[0]);
	}
	
	mysql_close (conn);
	return 0;
}

int main(int argc, char *argv[])
{	
	int sock_conn, sock_listen, ret;
	struct sockaddr_in serv_adr;
	char peticion[512];
	char respuesta[512];
	char userName[20];
	char password[20];
	// INICIALITZACIONS
	// Obrim el socket
	if ((sock_listen = socket(AF_INET, SOCK_STREAM, 0)) < 0)
		printf("Error creant socket");
	// Fem el bind al port
	
	memset(&serv_adr, 0, sizeof(serv_adr));// inicialitza a zero serv_addr
	serv_adr.sin_family = AF_INET;
	
	// asocia el socket a cualquiera de las IP de la m?quina. 
	//htonl formatea el numero que recibe al formato necesario
	serv_adr.sin_addr.s_addr = htonl(INADDR_ANY);
	// establecemos el puerto de escucha
	serv_adr.sin_port = htons(9040);
	if (bind(sock_listen, (struct sockaddr *) &serv_adr, sizeof(serv_adr)) < 0)
		printf ("Error al bind");
	
	if (listen(sock_listen, 3) < 0)
		printf("Error en el Listen");
	
	// Atiende 5 peticiones
	int i;
	// Bucle infinito
	for (;;){
		printf ("Escuchando\n");
		
		sock_conn = accept(sock_listen, NULL, NULL);
		printf ("He recibido conexion\n");
		//sock_conn es el socket que usaremos para este cliente
		
		int terminar =0;
		// Entramos en un bucle para atender todas las peticiones de este cliente
		//hasta que se desconecte
		while (terminar ==0)
		{
			// Ahora recibimos la petici?n
			ret=read(sock_conn,peticion, sizeof(peticion));
			printf ("Recibido\n");
			
			// Tenemos que a?adirle la marca de fin de string 
			// para que no escriba lo que hay despues en el buffer
			peticion[ret]='\0';
			
			
			printf ("Peticion: %s\n",peticion);
			
			// vamos a ver que quieren
			char *p = strtok( peticion, "/");
			int codigo =  atoi (p);
			// Ya tenemos el c?digo de la petici?n
			char nombre[20];
			char userName[20];
			char password[20];
			
			if (codigo !=0)
			{
				p = strtok( NULL, "/");
				strcpy (nombre, p);
				// Ya tenemos el nombre
				printf ("Codigo: %d, Nombre: %s\n", codigo, nombre);
			}
			
			if (codigo ==0) //petici?n de desconexi?n
				terminar=1;
			else if (codigo ==1) //do signUp
			{
				strcpy (userName, nombre);
				p = strtok( NULL, "/");
				strcpy (password, p);
				char mensajeSignUp[80];
				consultaSignUp(userName, password, mensajeSignUp);
				strcpy (respuesta,mensajeSignUp);
			}
			else if (codigo ==2) //check logIn
			{
				strcpy (userName, nombre);
				p = strtok( NULL, "/");
				strcpy (password, p);
				char mensajeLogIn[80];
				consultaLogIn(userName, password, mensajeLogIn);
				strcpy (respuesta,mensajeLogIn);
			}
			else if (codigo ==3) //piden la longitd del nombre
			{
				int puntosTotales = consulta1(nombre);
				sprintf (respuesta,"%d",puntosTotales);
			}
			else if (codigo ==4)
			{
				char puntuaciones[20];
				consulta2(nombre,puntuaciones);
				strcpy (respuesta,puntuaciones);				
			}
			else if (codigo == 5)//quiere saber si es alto
			{
				char ganador[20];
				char partidaID[10];
				consulta3(nombre,ganador);
				strcpy (respuesta,ganador);
				
				printf (ganador);
				printf (respuesta);
			}
			if (codigo !=0)
				{
				
				printf ("Respuesta: %s\n", respuesta);
				// Enviamos respuesta
				write (sock_conn,respuesta, strlen(respuesta));
				}
		}
		// Se acabo el servicio para este cliente
		close(sock_conn);
	}
	return 0;
}

