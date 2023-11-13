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
#include <pthread.h>

pthread_mutex_t mutex = PTHREAD_MUTEX_INITIALIZER;
int i;
int sockets[100];

typedef struct {
	char userName[20];
	int status; //1 for in game, 0 for in menu
	int socket;
} Usuario;

typedef struct {
	Usuario conectados[100];
	int num;
} ListaConectados;

typedef struct {
	Usuario jugadores[9];
	int numJugadores;
} Partida;

typedef struct {
	Partida partidas[100];
	int num;
} ListaPartidas;

ListaConectados lista_Conectados;
ListaPartidas lista_Partidas;

int consultaSignUp(MYSQL* conn, char userName[], char password[], char mensajeSignUp[]) {
	MYSQL_RES* resultado;
	MYSQL_ROW row;
	int err, n;
	char ID[10];

	char consulta[800];
	strcpy(consulta, "select exists(SELECT Jugador.userName FROM Jugador WHERE Jugador.userName = '");
	strcat(consulta, userName);
	strcat(consulta, "');");
	mysql_query(conn, consulta);
	resultado = mysql_store_result(conn);
	row = mysql_fetch_row(resultado);

	if (atoi(row[0]) == 0)
	{
		mysql_query(conn, "SELECT COUNT(ID) FROM Jugador");
		resultado = mysql_store_result(conn);
		row = mysql_fetch_row(resultado);
		n = atoi(row[0]) + 1;
		sprintf(ID, "%d", n);

		strcpy(consulta, "INSERT INTO Jugador VALUES ('");
		strcat(consulta, ID);
		strcat(consulta, "','");
		strcat(consulta, userName);
		strcat(consulta, "','");
		strcat(consulta, password);
		strcat(consulta, "');");

		printf("consulta = %s\n", consulta);
		// Ahora ya podemos realizar la insercion 
		err = mysql_query(conn, consulta);
		if (err != 0) {
			printf("Error al introducir datos la base %u %s\n",
				mysql_errno(conn), mysql_error(conn));
			exit(1);
		}
		strcpy(mensajeSignUp, "1/Se ha creado su usuario correctamente.");
	}
	else {
		strcpy(mensajeSignUp, "2/El usuario ya existe, elija otro username.");
	}
	// cerrar la conexion con el servidor MYSQL 
	mysql_close(conn);
	return 0;
}

int consultaLogIn(MYSQL* conn, char userName[], char password[], char mensajeLogIn[]) {
	MYSQL_RES* resultado;
	MYSQL_ROW row;
	char consulta[800];
	int err, n;
	char ID[10];

	strcpy(consulta, "select exists(SELECT Jugador.userName FROM Jugador WHERE Jugador.userName = '");
	strcat(consulta, userName);
	strcat(consulta, "');");
	mysql_query(conn, consulta);
	resultado = mysql_store_result(conn);
	row = mysql_fetch_row(resultado);
	int i;

	if (atoi(row[0]) == 1)
	{
		strcpy(consulta, "select exists(SELECT Jugador.pssword FROM Jugador WHERE Jugador.userName = '");
		strcat(consulta, userName);
		strcat(consulta, "' AND Jugador.pssword = '");
		strcat(consulta, password);
		strcat(consulta, "');");
		mysql_query(conn, consulta);
		resultado = mysql_store_result(conn);
		row = mysql_fetch_row(resultado);

		if (atoi(row[0]) == 1)
		{
			// Ahora ya podemos realizar la insercion 
			err = mysql_query(conn, consulta);
			if (err != 0) {
				printf("Error al introducir datos la base %u %s\n",
					mysql_errno(conn), mysql_error(conn));
				exit(1);
			}
			strcpy(mensajeLogIn, "3/");
			strcat(mensajeLogIn, "Se ha iniciado sesion correctamente.");
			i = 0;
		}
		else {
			strcpy(mensajeLogIn, "4/");
			strcat(mensajeLogIn, "La contrasenya que ha introducido es incorrecta.");
			i = 1;
		}
	}
	else {
		strcpy(mensajeLogIn, "5/");
		strcat(mensajeLogIn, "El usuario no existe, cree un usuario.");
		i = 2;
	}
	// cerrar la conexion con el servidor MYSQL 
	mysql_close(conn);
	return i;
}

int consulta1(MYSQL* conn, char nombre[])
{
	int err;
	MYSQL_RES* resultado;
	MYSQL_ROW row;

	char consulta[800];
	strcpy(consulta, "SELECT SUM(PartidasJugadores.puntuacion) FROM Jugador,Partida,PartidasJugadores WHERE Jugador.userName = '");
	strcat(consulta, nombre);
	strcat(consulta, "' AND Partida.ID = PartidasJugadores.ID_Partida AND PartidasJugadores.ID_jugador = Jugador.ID");
	mysql_query(conn, consulta);

	resultado = mysql_store_result(conn);
	row = mysql_fetch_row(resultado);

	if (row == NULL)
		printf("No se han obtenido datos en la consulta\n");

	int puntosTotales = atoi(row[0]);
	mysql_close(conn);
	return puntosTotales;
}

int consulta2(MYSQL* conn, char nombre[], char puntuaciones[])
{
	int err;
	MYSQL_RES* resultado;
	MYSQL_ROW row;

	char consulta[800];
	strcpy(consulta, "SELECT PartidasJugadores.Puntuacion FROM Jugador,Partida,PartidasJugadores WHERE Jugador.userName = '");
	strcat(consulta, nombre);
	strcat(consulta, "' AND Partida.ID = PartidasJugadores.ID_Partida AND PartidasJugadores.ID_jugador = Jugador.ID");
	mysql_query(conn, consulta);

	resultado = mysql_store_result(conn);
	row = mysql_fetch_row(resultado);

	if (row == NULL)
		printf("Ha habido un error en la consulta de datos \n");
	else
	{
		int i = 0;
		strcpy(puntuaciones, "12/");
		while (row != NULL) {
			strcat(puntuaciones, row[0]);
			strcat(puntuaciones, "/");
			row = mysql_fetch_row(resultado);
			i++;
		}
	}
	mysql_close(conn);
	return 0;
}

int consulta3(MYSQL* conn, char partidaID[], char ganador[])
{
	MYSQL_RES* resultado;
	MYSQL_ROW row;

	char consulta[800];
	strcpy(consulta, "SELECT Partida.ganador FROM Partida WHERE Partida.ID = '");
	strcat(consulta, partidaID);
	strcat(consulta, "';");
	mysql_query(conn, consulta);

	resultado = mysql_store_result(conn);
	row = mysql_fetch_row(resultado);

	if (row == NULL)
		printf("Ha habido un error en la consulta de datos \n");
	else {
		strcpy(ganador, "13/");
		strcat(ganador, row[0]);
	}
	mysql_close(conn);
	return 0;
}

void consultaConectados(ListaConectados* lista, char conectados[300]) {
	char sockets[100];
	strcpy(conectados, "10/");
	//strcpy(sockets,"Sockets:/");
	for (int i = 0; i < lista->num; i++) {
		sprintf(conectados, "%s%s.%d.", conectados, lista->conectados[i].userName, lista->conectados[i].status);
		//sprintf (sockets, "%s%s.%d.%d.", sockets, lista->conectados[i].userName, lista->conectados[i].status, lista->conectados[i].socket);
	}
	//printf(sockets); check
}

int PonConectado(ListaConectados* lista, char nombre[20], int socket)
{
	if (lista->num == 100)
		return -1;
	else
	{
		pthread_mutex_lock(&mutex);
		strcpy(lista->conectados[lista->num].userName, nombre);
		lista->conectados[lista->num].status = 0;
		lista->conectados[lista->num].socket = socket;
		lista->num++;
		pthread_mutex_unlock(&mutex);
		return 0;
	}
}

int EliminarConectado(ListaConectados* lista, char nombre[20])
{
	int encontrado = 0;
	for (int i = 0; i < lista->num; i++) {
		if (strcmp(lista->conectados[i].userName, nombre) == 0) {
			encontrado = 1;
			break;
		}
	}
	pthread_mutex_lock(&mutex);
	if (encontrado == 1) {
		for (int i = 0; i < lista->num - 1; i++)
		{
			if (strcmp(lista->conectados[i].userName, nombre) == 0)
				lista->conectados[i] = lista->conectados[i + 1];
		}
		lista->num--;
	}
	pthread_mutex_unlock(&mutex);
	return 0;
}

int CrearPartida(ListaPartidas* lista, char nombre[])
{
	int numJugador = 0;
	if (lista->num == 100)
		return -1;
	else
	{
		numJugador = lista->partidas[lista->num].numJugadores;
		pthread_mutex_lock(&mutex);
		strcpy(lista->partidas[lista->num].jugadores[numJugador], nombre);	// Fica el nom del jugador que l'ha creat
		lista->partidas[lista->num].jugadores[numJugador].status = 1;		// 1 = InGame
		lista->partidas[lista->num].jugadores[numJugador].socket = socket;	// Socket de l'usuari
		lista->num++;														// Aquesta partida es guarda a lista[i] -> la seguent partida es guarda a lista[i+1]
		pthread_mutex_unlock(&mutex);
		return 0;
	}
}

int EnviarInvitacion(ListaConectados* listaC, ListaPartidas* listaP, char infoInvitados[], char sockets_receptores[], char invitacio[])
{
	char host[20];

	p = strtok(infoInvitados, "/");
	strcpy(host, p);

	strcpy(invitacion, "6/");
	strcat(invitacion, host);

	char receptor[20];
	strcpy(sockets_receptores, "");

	p = strtok(NULL, "/");
	strcpy(receptor, p);

	int encontrado = -1;
	for (int n = 0; p != NULL; i++)
	{
		for (int i = 0; i < listaC->num; i++) {
			if (strcmp(listaC->conectados[i].userName, receptor) == 0) {
				socket_receptor = listaC->conectados[i].socket;
				encontrado = i;
				break;
			}
		}
		if (encontrado != -1) {
			if (listaC->conectados[i].status == 1) {
				strcat(sockets_receptores, listaC->conectados[i].socket);
				strcat(sockets_receptores, "/")
			}
			else {
				strcat(sockets_receptores, listaC->conectados[i].socket);
				strcat(sockets_receptores,"/")
			}
		}
		p = strtok(infoInvitados, "/");
		strcpy(receptor, p);
	}
	return 0;
}

int UnirsePartida()
{
	// Si responde que si, se updatea la lista de jugadores de la partida y se informa al host
	// Si responde que no, se devuelve la informacion al host y ya

}

void AtenderCliente(void* socket)
{
	int sock_conn;
	int* s;
	s = (int*)socket;
	sock_conn = *s;
	MYSQL* conn;

	char peticion[512];
	char respuesta[512];
	int ret;
	int terminar = 0;

	// Entramos en un bucle para atender todas las peticiones de este cliente
	//hasta que se desconecte
	while (terminar == 0)
	{
		char nombre[20];
		char userName[20];
		char password[20];
		// Ahora recibimos la petici?n
		ret = read(sock_conn, peticion, sizeof(peticion));
		printf("Recibido\n");

		// Tenemos que a?adirle la marca de fin de string 
		// para que no escriba lo que hay despues en el buffer
		peticion[ret] = '\0';
		printf("Peticion: %s\n", peticion);

		// vamos a ver que quieren
		char* p = strtok(peticion, "/");
		int codigo = atoi(p);
		// Ya tenemos el c?digo de la petici?n

		int err;
		conn = mysql_init(NULL);
		if (conn == NULL) {
			printf("Error en conexion: %u %s\n", mysql_errno(conn), mysql_error(conn));
			exit(1);
		}
		// conn = mysql_real_connect (conn, "shiva2.upc.es","root", "mysql", "T6_Juego", 0, NULL, 0);	//Shiva
		conn = mysql_real_connect(conn, "localhost", "root", "mysql", "T6_Juego", 0, NULL, 0);			//Linux
		if (conn == NULL) {
			printf("Error en conexion: %u %s\n", mysql_errno(conn), mysql_error(conn));
			exit(1);
		}

		if ((codigo != 0) && (codigo != 6))	
		{
			// Ya tenemos el nombre
			printf("Codigo: %d, Nombre: %s\n", codigo, nombre);
		}
		if (codigo == -1)
		{
			terminar = 1;
		}
		else if (codigo == 0) //peticion de desconexion
		{
			p = strtok(NULL, "/");
			strcpy(userName, p);
			EliminarConectado(&lista_Conectados, userName);
			terminar = 1;
		}
		else if (codigo == 1) //do signUp
		{
			strcpy(userName, nombre);
			p = strtok(NULL, "/");
			strcpy(password, p);
			char mensajeSignUp[80];
			consultaSignUp(conn, userName, password, mensajeSignUp);
			strcpy(respuesta, mensajeSignUp);
		}
		else if (codigo == 2) //check logIn
		{
			strcpy(userName, nombre);
			p = strtok(NULL, "/");
			strcpy(password, p);
			char mensajeLogIn[80];
			int login = consultaLogIn(conn, userName, password, mensajeLogIn);
			strcpy(respuesta, mensajeLogIn);
			if (login == 0)
				PonConectado(&lista_Conectados, userName, sock_conn);
		}
		else if (codigo = 3)		// 3/Host/Asier/Julia/Gu... tots els invitados (fins a 8)
		{
			char invitacion[20];
			char sockets_receptores[20];
			char infoInvitados[80];
			int err;

			p = strtok(NULL, "/");
			strcpy(infoInvitados, p);
			err = EnviarInvitacion(&ListaConectados, &ListaPartidas, infoInvitados, sockets_receptores, invitacion);

			strcpy(respuesta, "9/");
			strcat(respuesta, err);

			int socket;
			p = strtok(NULL, "/");
			strcpy(sockets_receptores, p);
			while (p != NULL)
			{
				p = strtok(sockets_receptores, "/");
				socket = atoi(p);
				write(socket, invitacion, strlen(invitacion));

				p = strtok(NULL, "/");
				strcpy(sockets_receptores, p);
			}
		}
		else if (codigo = 4)
		{
			p = strtok(NULL, "/");
			strcpy(infoRespuesta, p);
		}
		else if (codigo = 5)
		{
			p = strtok(NULL, "/");
			strcpy(host, p);
			int err;
			err = CrearPartida(&lista_Partidas, host);
			strcpy(respuesta, "8/");
			strcat(respuesta, err);
		}
		else if (codigo == 10)		// Consulta usuarios conectados
		{
			char conectados[800];
			consultaConectados(&lista_Conectados, conectados);
			strcpy(respuesta, conectados);
		}
		else if (codigo == 11)		// Consulta puntuacion total
		{
			p = strtok(NULL, "/");
			strcpy(nombre, p);
			int puntosTotales = consulta1(conn, nombre);
			sprintf(respuesta, "11/%d", puntosTotales);
		}
		else if (codigo == 12)		// Consulta todas las puntuaciones 
		{
			p = strtok(NULL, "/");
			strcpy(nombre, p);
			char puntuaciones[20];
			consulta2(conn, nombre, puntuaciones);
			strcpy(respuesta, puntuaciones);
		}
		else if (codigo == 13)		// Consulta ganador de partida
		{
			p = strtok(NULL, "/");
			strcpy(partida, p);
			char ganador[20];
			char partidaID[10];
			consulta3(conn, partida, ganador);
			strcpy(respuesta, ganador);
		}
		if (codigo != 0)
		{
			printf("Respuesta: %s\n", respuesta);		
			write(sock_conn, respuesta, strlen(respuesta));		// Enviamos respuesta
		}
		if ((codigo == 0) || (codigo == 2))		// Se actualiza a todo el mundo la tabla de conectados
		{
			char conectados[800];
			consultaConectados(&lista_Conectados, conectados);
			char notificacion[800];
			strcpy(notificacion, conectados);
			int j;
			for (j = 0; j < i; j++)
				write(sockets[j], notificacion, strlen(notificacion));
		}
	}
	// Se acabo el servicio para este cliente
	close(sock_conn);
}




int main(int argc, char* argv[])
{
	int sock_conn, sock_listen, ret;
	struct sockaddr_in serv_adr;
	if ((sock_listen = socket(AF_INET, SOCK_STREAM, 0)) < 0)
		printf("Error creant socket");
	// Fem el bind al port

	// int puerto = 50075;  //50075-50090 for Shiva
	int puerto = 9075; 		//Linux

	memset(&serv_adr, 0, sizeof(serv_adr));// inicialitza a zero serv_addr
	serv_adr.sin_family = AF_INET;

	// asocia el socket a cualquiera de las IP de la m?quina. 
	//htonl formatea el numero que recibe al formato necesario
	serv_adr.sin_addr.s_addr = htonl(INADDR_ANY);
	// establecemos el puerto de escucha
	serv_adr.sin_port = htons(puerto);
	if (bind(sock_listen, (struct sockaddr*)&serv_adr, sizeof(serv_adr)) < 0)
		printf("Error al bind");

	if (listen(sock_listen, 3) < 0)
		printf("Error en el Listen");

	lista_Conectados.num = 0;
	lista_Partidas.num = 0;
	pthread_t thread;
	// Bucle infinito
	for (;;) {
		printf("Escuchando\n");

		sock_conn = accept(sock_listen, NULL, NULL);
		printf("He recibido conexion\n");
		//sock_conn es el socket que usaremos para este cliente

		sockets[i] = sock_conn;
		pthread_create(&thread, NULL, AtenderCliente, &sockets[i]);
		i = i + 1;
	}
	return 0;
}


