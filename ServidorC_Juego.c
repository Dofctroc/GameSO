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
	strcpy(sockets,"");
	for (int i = 0; i < lista->num; i++) {
		sprintf(conectados, "%s%s.%d.", conectados, lista->conectados[i].userName, lista->conectados[i].status);
		sprintf (sockets, "%s%s.%d.%d.", sockets, lista->conectados[i].userName, lista->conectados[i].status, lista->conectados[i].socket);
	}
	printf("Sockets de conectados: %s \n", sockets);
}

int PonConectado(ListaConectados* lista, char nombre[20], int socketUsuario)
{
	if (lista->num == 100)
		return -1;
	else
	{
		pthread_mutex_lock(&mutex);
		strcpy(lista->conectados[lista->num].userName, nombre);
		lista->conectados[lista->num].status = 0;
		lista->conectados[lista->num].socket = socketUsuario;
		lista->num++;
		pthread_mutex_unlock(&mutex);
		return 0;
	}
}

int EliminarConectado(ListaConectados* lista, char nombre[20])
{
	int encontrado = 0;
	for (int i = 0; i < lista->num; i++)
	{
		if (strcmp(lista->conectados[i].userName, nombre) == 0)
		{
			encontrado = 1;
			break;
		}
	}
	pthread_mutex_lock(&mutex);
	if (encontrado == 1) {
		for (int i = 0; i < lista->num - 1; i++)
		{
			if (strcmp(lista->conectados[i].userName, nombre) == 0)
				for (int j = i; j < lista->num-1; j++)
					lista->conectados[j] = lista->conectados[j + 1];
		}
		lista->num--;
	}
	pthread_mutex_unlock(&mutex);
	return 0;
}

int CrearPartida(ListaPartidas* listaP, char nombre[], int socketUsuario)
{
	if (listaP->num == 100)
		return -1;
	else
	{
		pthread_mutex_lock(&mutex);
		strcpy(listaP->partidas[listaP->num].jugadores[0].userName, nombre);	// Fica el nom del jugador que l'ha creat
		listaP->partidas[listaP->num].jugadores[0].status = 1;					// 1 = InGame
		listaP->partidas[listaP->num].jugadores[0].socket = socketUsuario;				// Socket de l'usuari
		listaP->partidas[listaP->num].numJugadores++;
		listaP->num++;															// Aquesta partida es guarda a lista[i] -> la seguent partida es guarda a lista[i+1]
		pthread_mutex_unlock(&mutex);
		return 0;
	}
}

int EnviarInvitacion(ListaConectados* listaC, ListaPartidas* listaP, char infoInvitados[], char sockets_receptores[], char invitacion[])
{
	char host[20];
	char receptor[20];
	
	strcpy(sockets_receptores, "");
	char* p = strtok(infoInvitados, ".");
	strcpy(host, p);
	
	p = strtok(NULL, ".");
	strcpy(receptor, p);
	printf("Receptor: %s \n", receptor);
	for (int n = 0; p != NULL; n++) {
		strcpy(receptor, p);
		for (int i = 0; i < listaC->num; i++) {
			if (strcmp(listaC->conectados[i].userName, receptor) == 0) {
				printf("Su socket: %d \n", listaC->conectados[i].socket);
				sprintf(sockets_receptores, "%s%d/", sockets_receptores,listaC->conectados[i].socket);
				break;
			}
		}
		p = strtok(NULL, ".");
	}
	
	printf("Sockets: %s \n", sockets_receptores);
	strcpy(invitacion, "22/");
	strcat(invitacion, host);
	return 0;
}

int PonJugadorPartida(ListaConectados* listaC, ListaPartidas* listaP, char nombre[20], char host[20])
{
	char datosPartida[200];
	int socketUsuario;
	for (int i = 0; i < listaP->num; i++) {
		if (strcmp(listaP->partidas[i].jugadores[0].userName, host) == 0){
			printf("Host: %s\n", host);
			pthread_mutex_lock(&mutex);
			strcpy(listaP->partidas[i].jugadores[listaP->partidas[i].numJugadores].userName, nombre);
			listaP->partidas[i].jugadores[listaP->partidas[i].numJugadores].status = 1;
			for (int i = 0; i < listaC->num; i++) {
				if (strcmp(listaC->conectados[i].userName, nombre) == 0) {
					socketUsuario = listaC->conectados[i].socket;
					break;
				}
			}
			listaP->partidas[i].jugadores[listaP->partidas[i].numJugadores].socket = socketUsuario;
			listaP->partidas[i].numJugadores++;
			pthread_mutex_unlock(&mutex);
			break;
		}
	}
	return 0;
}

int EliminarJugadorPartida(ListaPartidas* listaP, char nombre[20], char host[20])
{
	for (int i = 0; i < listaP->num; i++) {
		if (strcmp(listaP->partidas[i].jugadores[0].userName, host) == 0)
		{
			pthread_mutex_lock(&mutex);
			for (int j = 0; j < listaP->partidas[i].numJugadores; j++)
			{
				if (strcmp(listaP->partidas[i].jugadores[j].userName, nombre) == 0)
					for (int k = j; k < listaP->partidas[i].numJugadores - 1; k++)
						listaP->partidas[i].jugadores[k] = listaP->partidas[i].jugadores[k + 1];
			}
			listaP->partidas[i].numJugadores--;
			pthread_mutex_unlock(&mutex);
		}
	}
	return 0;
}

int BuscarSocket(ListaConectados* listaC, char persona[])
{
	int socketUsuario = -1;
	for (int i = 0; i < listaC->num; i++) {
		if (strcmp(listaC->conectados[i].userName, persona) == 0) {
			socketUsuario = listaC->conectados[i].socket;
			break;
		}
	return socketUsuario;
	}
}
	
int PartidaActualizada(ListaPartidas* listaP, char sockets_receptores[], char host[], char infoJugadoresPartida[])
{
	strcpy(sockets_receptores, "");
	strcpy(infoJugadoresPartida, "24/");
	
	for (int i = 0; i < listaP->num; i++) {
		if (strcmp(listaP->partidas[i].jugadores[0].userName, host) == 0) 
		{
			for (int n = 0; n < listaP->partidas[i].numJugadores; n++) {
				sprintf(sockets_receptores, "%s%d/", sockets_receptores, listaP->partidas[i].jugadores[n].socket);
			}
			break;
		}
	}
	for (int i = 0; i < listaP->num; i++) {
		if (strcmp(listaP->partidas[i].jugadores[0].userName, host) == 0){
			for (int n = 0; n < listaP->partidas[i].numJugadores; n++)
			{
				strcat(infoJugadoresPartida,listaP->partidas[i].jugadores[n].userName);
				strcat(infoJugadoresPartida,".");
			}
		}
	}
	printf("Jugadores: %s \n", infoJugadoresPartida);
	printf("Sockets: %s \n", sockets_receptores);
	return 0;
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
		char partida[20];
		char host[20];
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
		//conn = mysql_real_connect (conn, "shiva2.upc.es","root", "mysql", "T6_Juego", 0, NULL, 0);	//Shiva
		conn = mysql_real_connect(conn, "localhost", "root", "mysql", "T6_Juego", 0, NULL, 0);			//Linux
		if (conn == NULL) {
			printf("Error en conexion: %u %s\n", mysql_errno(conn), mysql_error(conn));
			exit(1);
		}

		if (codigo == 0) //peticion de desconexion
		{
			p = strtok(NULL, "/");
			strcpy(userName, p);
			EliminarConectado(&lista_Conectados, userName);
			terminar = 1;
		}
		else if (codigo == 1) //do signUp
		{
			p = strtok(NULL, "/");
			strcpy(userName, p);
			p = strtok(NULL, "/");
			strcpy(password, p);
			char mensajeSignUp[80];
			consultaSignUp(conn, userName, password, mensajeSignUp);
			strcpy(respuesta, mensajeSignUp);
		}
		else if (codigo == 2) //check logIn
		{
			p = strtok(NULL, "/");
			strcpy(userName, p);
			p = strtok(NULL, "/");
			strcpy(password, p);
			char mensajeLogIn[80];
			int login = consultaLogIn(conn, userName, password, mensajeLogIn);
			strcpy(respuesta, mensajeLogIn);
			if (login == 0)
				PonConectado(&lista_Conectados, userName, sock_conn);
		}
		else if (codigo == 3)		// 3/Host/Asier/Julia/Gu... tots els invitados (fins a 8)
		{
			char invitacion[20];
			char sockets_receptores[20];
			char infoInvitados[80];
			int err;
			
			p = strtok(NULL, "/");
			strcpy(infoInvitados, p);
			printf("Info: %s \n", infoInvitados);
			
			err = EnviarInvitacion(&lista_Conectados, &lista_Partidas, infoInvitados, sockets_receptores, invitacion);
			sprintf(respuesta, "21/%d", err);

			int socketUsuario;
			p = strtok(sockets_receptores, "/");
			while (p != NULL)
			{
				socketUsuario = atoi(p);
				printf("Invitacion: %s \n", invitacion);
				write(socketUsuario, invitacion, strlen(invitacion));
				p = strtok(NULL, "/");
			}
		}
		else if (codigo == 4)
		{
			char invitado[20];
			char decision[20];
			char actualizacion[20];
			char sockets_receptores[20];
			char infoJugadoresPartida[100];
			int socketHost;
			strcpy (sockets_receptores,"");
			strcpy (actualizacion,"");
			
			p = strtok(NULL, "/");
			strcpy(host, p);
			
			socketHost = BuscarSocket(&lista_Conectados, host);
			if (socketHost != -1)
			{
				p = strtok(NULL, "/");
				strcpy(invitado, p);
				p = strtok(NULL, "/");
				strcpy(decision, p);
				printf("Decision: %s \n", decision);
				
				if (strcmp(decision,"Yes") == 0)
				{
					PonJugadorPartida(&lista_Conectados, &lista_Partidas, invitado, host);
					PartidaActualizada(&lista_Partidas, sockets_receptores, host, infoJugadoresPartida);
					
					int socketUsuario;
					p = strtok(sockets_receptores, "/");
					while (p != NULL)
					{
						socketUsuario = atoi(p);
						printf("InfoJugadoresPartida: %s \n", infoJugadoresPartida);
						write(socketUsuario, infoJugadoresPartida, strlen(infoJugadoresPartida));
						p = strtok(NULL, "/");
					}
				}
				
				sprintf(actualizacion, "23/%s/%s", invitado, decision);
				write(socketHost, actualizacion, strlen(actualizacion));
			}
		}
		else if (codigo == 5)
		{
			p = strtok(NULL, "/");
			strcpy(host, p);
			int err = CrearPartida(&lista_Partidas, userName, sock_conn);
			sprintf(respuesta, "20/%d", err);
		}
		else if (codigo == 10)
		{
			p = strtok(NULL, "/");
			strcpy(nombre, p);
			char conectados[800];
			consultaConectados(&lista_Conectados, conectados);
			strcpy(respuesta, conectados);
		}
		else if (codigo == 11) //piden la longitd del nombre
		{
			p = strtok(NULL, "/");
			strcpy(nombre, p);
			int puntosTotales = consulta1(conn, nombre);
			sprintf(respuesta, "11/%d", puntosTotales);
		}
		else if (codigo == 12)
		{
			p = strtok(NULL, "/");
			strcpy(partida, p);
			char puntuaciones[20];
			consulta2(conn, partida, puntuaciones);
			strcpy(respuesta, puntuaciones);
		}
		else if (codigo == 13)//quiere saber si es alto
		{
			char ganador[20];
			char partidaID[10];
			consulta3(conn, nombre, ganador);
			strcpy(respuesta, ganador);
		}
		if ((codigo != 0) && (codigo != 4))
		{
			printf("Respuesta: %s\n", respuesta);
			// Enviamos respuesta
			write(sock_conn, respuesta, strlen(respuesta));
		}
		if ((codigo == 0) || (codigo == 2))
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

	//int puerto = 50075;  //50075-50090 for Shiva
	int puerto = 9074; 		//Linux

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


