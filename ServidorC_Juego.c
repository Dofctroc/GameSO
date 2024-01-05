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
	Usuario jugadores[6];
	int colores[6];
	int numJugadores;
	int status;	//1 for in game, 0 for in lobby
} Partida;

typedef struct {
	Partida partidas[100];
	int num;
} ListaPartidas;

ListaConectados lista_Conectados;
ListaPartidas lista_Partidas;

// ------------------------- BUSQUEDAS ---------------------------------------------------------------------------
// ---------------------------------------------------------------------------------------------------------------

// Searches for the position of the user "persona" in lista_conectados
// If search is null returns -1
int BuscarConectado(ListaConectados* listaC, char persona[])
{
	for (int i = 0; i < listaC->num; i++)
		if (strcmp(listaC->conectados[i].userName, persona) == 0)
			return i;
	return -1;
}

// Searches for the socket of "persona"
// If search is null returns -1
int BuscarSocket(ListaConectados* listaC, char persona[])
{
	for (int i = 0; i < listaC->num; i++)
		if (strcmp(listaC->conectados[i].userName, persona) == 0)
			return i;
			
	return -1;
}

// Searches for the game hosted by "host" in lista_partidas
// If search is null returns -1
int BuscarPartidaHost(ListaPartidas* listaP, char host[])
{
	for (int i = 0; i < listaP->num; i++)
		if (strcmp(listaP->partidas[i].jugadores[0].userName, host) == 0)
			return i;
	return -1;
}

void consultaConectados(ListaConectados* lista, char conectados[300]) {
	char sockets[100];
	strcpy(conectados, "");
	strcpy(sockets,"");
	for (int i = 0; i < lista->num; i++) {
		sprintf(conectados, "%s%s.%d.", conectados, lista->conectados[i].userName, lista->conectados[i].status);
		sprintf (sockets, "%s%s.%d.%d.", sockets, lista->conectados[i].userName, lista->conectados[i].status, lista->conectados[i].socket);
	}
	printf("Sockets de conectados: %s \n", sockets);
}

int JugadoresEnPartida(ListaPartidas* listaP, char sockets_receptores[], char host[], char infoJugadoresPartida[])
{
	strcpy(sockets_receptores, "");
	strcpy(infoJugadoresPartida, "");
	
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

int ColoresJugadoresEnPartida(ListaPartidas* listaP, char host[], char coloresJugadoresPartida[])
{
	strcpy(coloresJugadoresPartida, "");
	
	for (int i = 0; i < listaP->num; i++) {
		if (strcmp(listaP->partidas[i].jugadores[0].userName, host) == 0) 
		{
			for (int n = 0; n < listaP->partidas[i].numJugadores; n++) {
				sprintf(coloresJugadoresPartida, "%s%d.", coloresJugadoresPartida, listaP->partidas[i].colores[n]);
			}
			break;
		}
	}
	printf("Colores: %s \n", coloresJugadoresPartida);
	return 0;
}

// Searches for the game where "player" is in lista_partidas
// If search is null returns -1
int BuscarPartidaUsuario (ListaPartidas* listaP, char player[])
{
	for (int i = 0; i < listaP->num; i++)
		for (int j = 0; j < listaP->partidas[i].numJugadores; j++)
			if (strcmp(listaP->partidas[i].jugadores[j].userName, player) == 0)
				return i;
	return -1;
}

// Searches for the position where "player" is in "partida"
// If search is null returns -1
int BuscarUsuarioPartida (ListaPartidas* listaP, char player[], int partida)
{
	for (int j = 0; j < listaP->partidas[partida].numJugadores; j++)
		if (strcmp(listaP->partidas[partida].jugadores[j].userName, player) == 0)
			return j;
	return -1;
}

// ------------------------- ELIMINACIONES ---------------------------------------------------------------------------
// -------------------------------------------------------------------------------------------------------------------
int EliminarConectado(ListaConectados* lista, char nombre[])
{
	int encontrado = 0;
	for (int i = 0; i < lista->num; i++) {
		if (strcmp(lista->conectados[i].userName, nombre) == 0) {
			encontrado = 1;
			break;
		}
	}
	if (encontrado == 1) {
		for (int i = 0; i < lista->num - 1; i++) {
			if (strcmp(lista->conectados[i].userName, nombre) == 0)
				for (int j = i; j < lista->num-1; j++)
					lista->conectados[j] = lista->conectados[j + 1];
		}
		lista->num--;
	}
	return 0;
}

int EliminarJugadorPartida(ListaPartidas* listaP, char nombre[], char host[])
{
	int partida = BuscarPartidaHost(listaP, host);
	if (partida != -1)
	{
		for (int j = 0; j < listaP->partidas[partida].numJugadores; j++)
		{
			if (strcmp(listaP->partidas[partida].jugadores[j].userName, nombre) == 0)
				for (int k = j; k < listaP->partidas[partida].numJugadores - 1; k++)
					listaP->partidas[partida].jugadores[k] = listaP->partidas[partida].jugadores[k + 1];
		}
		listaP->partidas[partida].numJugadores--;
	}
	return 0;
}

int EliminarPartida(ListaPartidas* listaP, char host[])
{
	int partida = BuscarPartidaHost(listaP, host);
	if (partida != -1)
	{
		listaP->partidas[partida].numJugadores = 0;
		for (int k = partida; k < listaP->num - 1; k++)
			listaP->partidas[k] = listaP->partidas[k + 1];
		listaP->num--;
	}
	return 0;
}

int EliminarUsuario(MYSQL* conn, char nombre[], char password[], char mensajeSignOut[])
{
	MYSQL_RES* resultado;
	MYSQL_ROW row;
	int err, n;
	char ID[10];
	char consulta[800];
	char consulta2[800];
	strcpy(consulta, "select exists(SELECT Jugador.userName FROM Jugador WHERE Jugador.userName = '");
	strcat(consulta, nombre);
	strcat(consulta, "');");
	mysql_query(conn, consulta);
	resultado = mysql_store_result(conn);
	row = mysql_fetch_row(resultado);
	int i;
	
	if (atoi(row[0]) == 1)
	{
		strcpy(consulta, "select exists(SELECT Jugador.pssword FROM Jugador WHERE Jugador.userName = '");
		strcat(consulta, nombre);
		strcat(consulta, "' AND Jugador.pssword = '");
		strcat(consulta, password);
		strcat(consulta, "');");
		if (mysql_query(conn, consulta) != 0) {
			fprintf(stderr, "Error: %s\n", mysql_error(conn));
			exit(1);
		}
		resultado = mysql_store_result(conn);
		row = mysql_fetch_row(resultado);
		
		if (atoi(row[0]) == 1)
		{
			strcpy(mensajeSignOut, "3/0");
			strcpy(consulta, "SET FOREIGN_KEY_CHECKS=0;");
			if (mysql_query(conn, consulta) != 0) {
				fprintf(stderr, "Error: %s\n", mysql_error(conn));
			}
			strcpy(consulta, "DELETE FROM Jugador WHERE Jugador.userName = '");
			strcat(consulta, nombre);
			strcat(consulta, "';");
			if (mysql_query(conn, consulta) != 0) {
				fprintf(stderr, "Error: %s\n", mysql_error(conn));
			}
			strcpy(consulta, "SET FOREIGN_KEY_CHECKS=1;");
			if (mysql_query(conn, consulta) != 0) {
				fprintf(stderr, "Error: %s\n", mysql_error(conn));
			}
			i = 0;
		}
		else {
			strcpy(mensajeSignOut, "3/");
			strcat(mensajeSignOut, "La contrasenya que ha introducido es incorrecta.");
			i = 1;
		}
	}
	else {
		strcpy(mensajeSignOut, "3/");
		strcat(mensajeSignOut, "El usuario no existe, cree un usuario.");
		i = 2;
	}

	return i;
}

// ------------------------- INSERTACIONES ---------------------------------------------------------------------------
// -------------------------------------------------------------------------------------------------------------------
int PonConectado(ListaConectados* lista, char nombre[], int socketUsuario)
{
	if (lista->num == 100)
		return -1;
	else
	{
		strcpy(lista->conectados[lista->num].userName, nombre);
		lista->conectados[lista->num].status = 0;
		lista->conectados[lista->num].socket= socketUsuario;
		lista->num++;
		return 0;
	}
}

int CrearPartida(ListaPartidas* listaP, char nombre[], int socketUsuario)
{
	if (listaP->num == 100)
		return -1;
	else
	{
		strcpy(listaP->partidas[listaP->num].jugadores[0].userName, nombre);
		listaP->partidas[listaP->num].jugadores[0].status = 1;
		listaP->partidas[listaP->num].jugadores[0].socket = socketUsuario;	
		listaP->partidas[listaP->num].numJugadores++;
		listaP->num++;
		return 0;
	}
}

int PonJugadorPartida(ListaConectados* listaC, ListaPartidas* listaP, char nombre[], char host[])
{
	char datosPartida[200];
	int socketUsuario;
	
	for (int i = 0; i < listaP->num; i++) {
		if (strcmp(listaP->partidas[i].jugadores[0].userName, host) == 0){
			strcpy(listaP->partidas[i].jugadores[listaP->partidas[i].numJugadores].userName, nombre);
			for (int i = 0; i < listaC->num; i++) {
				if (strcmp(listaC->conectados[i].userName, nombre) == 0) {
					socketUsuario = listaC->conectados[i].socket;
					break;
				}
			}
			listaP->partidas[i].jugadores[listaP->partidas[i].numJugadores].socket = socketUsuario;
			listaP->partidas[i].numJugadores++;
			break;
		}
	}
	return 0;
}

// Asigna color al ultimo jugador de la partida, color no asignado (va del 1 al 6)
int AsignaColorJugador(ListaPartidas* listaP, char host[])
{
	int partidaIndex = BuscarPartidaHost(listaP,host);
	int color = 0;
	int freeColor = 1;
	
	for (color = 0; color < 6; color++)  // Cambiado a 6 para representar colores del 0 al 5
	{
		freeColor = 1;
		for (int i = 0; i < listaP->partidas[partidaIndex].numJugadores; i++)
		{
			if (listaP->partidas[partidaIndex].colores[i] == color)
			{
				freeColor = 0;
				break;  // Salir del bucle interno si el color está ocupado
			}
		}
		
		if (freeColor == 1)
		{
			listaP->partidas[partidaIndex].colores[listaP->partidas[partidaIndex].numJugadores] = color;
			return color;  // Devolver el primer color disponible
		}
	}
	return -1;
}

// ------------------------ ACTUALIZACIONES --------------------------------------------------------------------------
// -------------------------------------------------------------------------------------------------------------------
int actualizarEstadoUsuario(ListaConectados* listaC, char nombre[], int status)
{
	int usuario;
	usuario = BuscarConectado(listaC, nombre);
	if (usuario != -1){
		listaC->conectados[usuario].status = status;
	}
	return 0;
}

int actualizarEstadoPartida(ListaConectados* listaC, ListaPartidas* listaP, int partida, int status)
{
	if (partida != -1)
	{
		listaP->partidas[partida].status = status;
		for (int i = 0; i < listaP->partidas[partida].numJugadores; i++)
		{
			actualizarEstadoUsuario(listaC, listaP->partidas[partida].jugadores[i].userName, status);
			listaP->partidas[partida].jugadores[i].status = status;
		}
		return 0;		
	}
	return -1;
}

// --------------------------- CONSULTAS -----------------------------------------------------------------------------
// -------------------------------------------------------------------------------------------------------------------
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
		mysql_query(conn, "SELECT MAX(ID) FROM Jugador");
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
		
		// Ahora ya podemos realizar la insercion 
		err = mysql_query(conn, consulta);
		if (err != 0) {
			printf("Error al introducir datos la base %u %s\n",
				mysql_errno(conn), mysql_error(conn));
			exit(1);
		}
		strcpy(mensajeSignUp, "1/0");
	}
	else {
		strcpy(mensajeSignUp, "1/1");
	}
	// cerrar la conexion con el servidor MYSQL
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
			strcpy(mensajeLogIn, "2/0");
			i = 0;
		}
		else {
			strcpy(mensajeLogIn, "2/");
			strcat(mensajeLogIn, "La contrasenya que ha introducido es incorrecta.");
			i = 1;
		}
	}
	else {
		strcpy(mensajeLogIn, "2/");
		strcat(mensajeLogIn, "El usuario no existe, cree un usuario.");
		i = 2;
	}
	// cerrar la conexion con el servidor MYSQL
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

	if (row == NULL|| row[0] == NULL)
	{
		printf("No se han obtenido datos en la consulta\n");
		return -1;
	}

	int puntosTotales = atoi(row[0]);
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
	{
		printf("Ha habido un error en la consulta de datos \n");
		strcpy(puntuaciones, "12/NULL");
		return -1;
	}
	
	strcpy(puntuaciones, "12");
	while (row != NULL) {
		strcat(puntuaciones, "/");
		strcat(puntuaciones, row[0]);
		row = mysql_fetch_row(resultado);
	}
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
	{
		printf("Ha habido un error en la consulta de datos \n");
		strcpy(ganador, "13/NULL");
	}
	else {
		strcpy(ganador, "13/");
		strcat(ganador, row[0]);
	}
	return 0;
}

int consultaRanking1(MYSQL* conn, char infoRanking[]) 
{
	strcpy(infoRanking, "");
	// Ranking puntuacion total de cada jugador
	// Formato: Jug1.Punt1.Jug2.Punt2... (Preferiblemente en ordenn)
	int err;
	MYSQL_RES* resultado;
	MYSQL_ROW row;
	
	char consulta[800];
	strcpy(consulta, "SELECT Jugador.userName AS NombreJugador, "
		   " ( SELECT SUM(PartidasJugadores.puntuacion) FROM PartidasJugadores WHERE Jugador.ID = PartidasJugadores.ID_Jugador ) "
		   " AS PuntuacionTotal "
		   " FROM Jugador "
		   " ORDER BY PuntuacionTotal DESC;");
	if (mysql_query(conn, consulta) != 0) {
		fprintf(stderr, "Error ejecutando el query: %s\n", mysql_error(conn));
		return -1;
	}
	
	resultado = mysql_store_result(conn);
	row = mysql_fetch_row(resultado);
	
	if (row == NULL)
	{
		printf("Ha habido un error en la consulta de datos \n");
		strcpy(infoRanking, "13/NULL");
		return -1;
	}
	
	while (row != NULL) {
		sprintf (infoRanking, "%s%s.%s.", infoRanking, row[0], row[1]);
		printf("NombreJugador: %s, PuntuacionTotal: %s\n", row[0], row[1]);
		row = mysql_fetch_row(resultado);
	}
	return 0;
}

int consultaRanking2(MYSQL* conn, char infoRanking[])
{
	strcpy(infoRanking, "");
	// Ranking puntuacion total de cada jugador
	// Formato: Jug1.Punt1.Jug2.Punt2... (Preferiblemente en ordenn)
	int err;
	MYSQL_RES* resultado;
	MYSQL_ROW row;

	char consulta[800];
	strcpy(consulta, "SELECT Jugador.userName AS NombreJugador, "
		"(SELECT COUNT(PartidasJugadores.ID_Partida) FROM PartidasJugadores WHERE Jugador.ID = PartidasJugadores.ID_Jugador ) "
		"AS CantidadPartidasJugadas "
		"FROM Jugador "
		"ORDER BY CantidadPartidasJugadas DESC; ");
	if (mysql_query(conn, consulta) != 0) {
		fprintf(stderr, "Error ejecutando el query: %s\n", mysql_error(conn));
		return -1;
	}

	resultado = mysql_store_result(conn);
	row = mysql_fetch_row(resultado);

	if (row == NULL)
	{
		printf("Ha habido un error en la consulta de datos \n");
		strcpy(infoRanking, "13/NULL");
		return -1;
	}

	while (row != NULL) {
		sprintf(infoRanking, "%s%s.%s.", infoRanking, row[0], row[1]);
		printf("NombreJugador: %s, CantidadPartidasJugadas: %s\n", row[0], row[1]);
		row = mysql_fetch_row(resultado);
	}
	return 0;
}

int consultaInfoJugador(MYSQL* conn, char nombreJugador[], char infoRanking[])
{
	strcpy(infoRanking, "");
	// Ranking puntuacion total de cada jugador
	// Formato: Jug1.Punt1.Jug2.Punt2... (Preferiblemente en ordenn)
	int err;
	MYSQL_RES* resultado;
	MYSQL_ROW row;

	char consulta[800];
	strcpy(consulta, "SELECT Partida.ID AS IDPartida, PartidasJugadores.posicion AS Posicion, PartidasJugadores.puntuacion AS Puntuacion "
		"FROM Jugador, Partida, PartidasJugadores "
		"WHERE Jugador.ID = PartidasJugadores.ID_Jugador "
		"AND Partida.ID = PartidasJugadores.ID_Partida "
		"AND Jugador.userName = '");
	strcat(consulta, nombreJugador);
	strcat(consulta, "' ORDER BY IDPartida ASC; ");
	if (mysql_query(conn, consulta) != 0) {
		fprintf(stderr, "Error ejecutando el query: %s\n", mysql_error(conn));
		return -1;
	}

	resultado = mysql_store_result(conn);
	row = mysql_fetch_row(resultado);

	if (row == NULL)
	{
		printf("Ha habido un error en la consulta de datos \n");
		strcpy(infoRanking, "13/NULL");
		return -1;
	}

	while (row != NULL) {
		sprintf(infoRanking, "%s%s.%s.%s.", infoRanking, row[0], row[1], row[2]);
		printf("IDPartida: %s, Posicion: %s, Puntuacion: %s\n", row[0], row[1], row[2]);
		row = mysql_fetch_row(resultado);
	}
	return 0;
}

int consultaInfoPartida(MYSQL* conn, char idPartida[], char infoRanking[])
{
	strcpy(infoRanking, "");
	// Ranking puntuacion total de cada jugador
	// Formato: Jug1.Punt1.Jug2.Punt2... (Preferiblemente en ordenn)
	int err;
	MYSQL_RES* resultado;
	MYSQL_ROW row;
	
	char consulta[800];
	strcpy(consulta, "SELECT Jugador.userName AS Username, PartidasJugadores.posicion AS Posicion, PartidasJugadores.puntuacion AS Puntuacion "
		   "FROM Jugador, Partida, PartidasJugadores "
		   "WHERE Jugador.ID = PartidasJugadores.ID_Jugador "
		   "AND Partida.ID = PartidasJugadores.ID_Partida "
		   "AND Partida.ID = '");
	strcat(consulta, idPartida);
	strcat(consulta, "' ORDER BY Posicion ASC; ");
	if (mysql_query(conn, consulta) != 0) {
		fprintf(stderr, "Error ejecutando el query: %s\n", mysql_error(conn));
		return -1;
	}
	
	resultado = mysql_store_result(conn);
	row = mysql_fetch_row(resultado);
	
	if (row == NULL)
	{
		printf("Ha habido un error en la consulta de datos \n");
		strcpy(infoRanking, "13/NULL");
		return -1;
	}
	
	while (row != NULL) {
		sprintf (infoRanking, "%s%s.%s.%s.", infoRanking, row[0], row[1], row[2]);
		printf("IDPartida: %s, Posicion: %s, Puntuacion: %s\n", row[0], row[1], row[2]);
		row = mysql_fetch_row(resultado);
	}
	return 0;
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

// -------------------- MAIN: ATENDER CLIENTE ------------------------------------------------------------------------
// -------------------------------------------------------------------------------------------------------------------
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
	// Entramos en un bucle para atender todas las peticiones de este cliente
	//hasta que se desconecte
	while (terminar == 0)
	{
		char conectados[800];
		char notificacion[800];
		
		char partida[20];
		char host[20];
		char userName[20];
		char password[20];
		char sockets_receptores[20];
		char infoJugadoresPartida[200];
		char mensaje[200];
		int socketUsuario;
		
		// Ahora recibimos la petici?n
		ret = read(sock_conn, peticion, sizeof(peticion));
		printf("Recibido\n");
		printf("Socket: %d\n", sock_conn);
		// Tenemos que a?adirle la marca de fin de string 
		// para que no escriba lo que hay despues en el buffer
		peticion[ret] = '\0';
		printf("Peticion: %s\n", peticion);

		// vamos a ver que quieren
		char* p = strtok(peticion, "/");
		int codigo = atoi(p);
		// Ya tenemos el c?digo de la petici?n

		if (codigo == 0) //peticion de desconexion
		{
			p = strtok(NULL, "/");
			strcpy(userName, p);
			
			// Check if user is at least logged in (Not the case when you sign up)
			if (BuscarConectado(&lista_Conectados,userName) != -1) {
				// Check if user is in a game lobby
				if (BuscarPartidaUsuario(&lista_Partidas, userName) == -1)
				{
					// Inform all players of exitting game
				}
				
				// Check if user is hosting a game
				int partida = BuscarPartidaHost(&lista_Partidas, userName);
				if (partida != -1)
				{
					// Inform all players game is deleted
					sprintf(mensaje, "26/%s", userName);
					
					pthread_mutex_lock(&mutex);
					int partida = BuscarPartidaHost(&lista_Partidas,userName);
					if (partida != -1)
					{
						JugadoresEnPartida(&lista_Partidas, sockets_receptores, userName, infoJugadoresPartida);
						EliminarPartida(&lista_Partidas,userName);
						p = strtok(sockets_receptores, "/");
						while (p != NULL)
						{
							socketUsuario = atoi(p);
							if (socketUsuario != sock_conn)
								write(socketUsuario, mensaje, strlen(mensaje));
							p = strtok(NULL, "/");
						}
						strcpy(respuesta, mensaje);
					}
					pthread_mutex_unlock(&mutex);
				}
				
				// Check if user is in an active game
				
				
				// Finally eliminate that user from conectados
				EliminarConectado(&lista_Conectados, userName);
				
				consultaConectados(&lista_Conectados, conectados);
				sprintf(notificacion, "10/%s",conectados);
				
				int j;
				for (j = 0; j < 100; j++)
					if (sockets[j] != -1)
						write(sockets[j], notificacion, strlen(notificacion));
			}
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
			
			if (BuscarConectado(&lista_Conectados,userName) != -1) {
				strcpy(respuesta, "2/Este usuario ya esta conectado");
			}
			else{
				char mensajeLogIn[80];
				int login = consultaLogIn(conn, userName, password, mensajeLogIn);
				if (login == 0)
					PonConectado(&lista_Conectados, userName, sock_conn);
				strcpy(respuesta, mensajeLogIn);
			}
		}
		else if (codigo == 3)
		{
			p = strtok(NULL, "/");
			strcpy(userName, p);
			p = strtok(NULL, "/");
			strcpy(password, p);
			char mensajeSignOut[800];
			EliminarUsuario(conn, userName, password, mensajeSignOut);
			EliminarConectado(&lista_Conectados, userName);
			strcpy(respuesta, mensajeSignOut);
		}
		// Residual code from when you could actively ask connected users
		else if (codigo == 10)
		{
			p = strtok(NULL, "/");
			strcpy(userName, p);
			
			consultaConectados(&lista_Conectados, conectados);
			sprintf(respuesta, "10/%s", conectados);
		}
		else if (codigo == 11)
		{
			p = strtok(NULL, "/");
			strcpy(userName, p);
			
			int puntosTotales = consulta1(conn, userName);
			sprintf(respuesta, "11/%d", puntosTotales);
		}
		else if (codigo == 12)
		{
			char puntuaciones[20];
			p = strtok(NULL, "/");
			strcpy(partida, p);
			
			consulta2(conn, partida, puntuaciones);
			strcpy(respuesta, puntuaciones);
		}
		else if (codigo == 13)
		{
			char ganador[20];
			char partidaID[10];
			p = strtok(NULL, "/");
			strcpy(partidaID, p);
			
			consulta3(conn, partidaID, ganador);
			strcpy(respuesta, ganador);
		}
		else if (codigo == 14)
		{
			char respuestaRanking[1000];
			err = consultaRanking1(conn,respuestaRanking);
			
			if (err == 0)
				sprintf(respuesta, "14/%s", respuestaRanking);
			else
				sprintf(respuesta, "14/0");
		}
		else if (codigo == 15)
		{
			char respuestaRanking[1000];
			err = consultaRanking2(conn,respuestaRanking);
			
			if (err == 0)
				sprintf(respuesta, "15/%s", respuestaRanking);
			else
				sprintf(respuesta, "15/0");
		}
		else if (codigo == 16)
		{
			char respuestaInfo[1000];
			p = strtok(NULL, "/");
			strcpy(userName, p);
			err = consultaInfoJugador(conn, userName ,respuestaInfo);
			
			if (err == 0)
				sprintf(respuesta, "16/%s", respuestaInfo);
			else
				sprintf(respuesta, "16/0");
		}
		else if (codigo == 17)
		{
			char respuestaInfo[1000];
			p = strtok(NULL, "/");
			strcpy(partida, p);
			err = consultaInfoPartida(conn, partida ,respuestaInfo);
			
			if (err == 0)
				sprintf(respuesta, "17/%s", respuestaInfo);
			else
				sprintf(respuesta, "17/0");
		}
		else if (codigo == 20)
		{
			char coloresJugadoresPartida[20];
			p = strtok(NULL, "/");
			strcpy(host, p);
			int err = CrearPartida(&lista_Partidas, host, sock_conn);
			int color = AsignaColorJugador(&lista_Partidas, host);
			ColoresJugadoresEnPartida(&lista_Partidas, host, coloresJugadoresPartida);
			printf("Color asignado: %d \n",color);
			sprintf(respuesta, "20/%s/%d/%s", host, err, coloresJugadoresPartida);
		}
		else if (codigo == 21)		// 3/Host/Asier/Julia/Gu... tots els invitados (fins a 8)
		{
			char invitacion[20];
			char sockets_receptores[20];
			char infoInvitados[80];
			int err;
			
			p = strtok(NULL, "/");
			strcpy(infoInvitados, p);
			printf("Info: %s \n", infoInvitados);
			
			err = EnviarInvitacion(&lista_Conectados, &lista_Partidas, infoInvitados, sockets_receptores, invitacion);
			sprintf(respuesta, "21/%s/%d", host, err);
			
			p = strtok(sockets_receptores, "/");
			while (p != NULL)
			{
				socketUsuario = atoi(p);
				printf("Invitacion: %s \n", invitacion);
				write(socketUsuario, invitacion, strlen(invitacion));
				p = strtok(NULL, "/");
			}
		}
		else if (codigo == 23)
		{
			char invitado[20];
			char decision[20];
			char actualizacion[20];
			char coloresJugadoresPartida[20];
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
				
				if (strcmp(decision,"Yes") == 0)
				{
					PonJugadorPartida(&lista_Conectados, &lista_Partidas, invitado, host);
					AsignaColorJugador(&lista_Partidas, host);
				}
				
				JugadoresEnPartida(&lista_Partidas, sockets_receptores, host, infoJugadoresPartida);
				ColoresJugadoresEnPartida(&lista_Partidas, host, coloresJugadoresPartida);
				
				sprintf(actualizacion, "23/%s/%s/%s/%s", host, invitado, decision, coloresJugadoresPartida);
				
				p = strtok(sockets_receptores, "/");
				while (p != NULL)
				{
					socketUsuario = atoi(p);
					if (socketUsuario != sock_conn)
						write(socketUsuario, actualizacion, strlen(actualizacion));
					p = strtok(NULL, "/");
				}
				
				if (strcmp(decision,"Yes") == 0)
					sprintf(respuesta, "30/%s/%s/%s", host, infoJugadoresPartida, coloresJugadoresPartida);
				else 
					sprintf(respuesta, "30/%s/0", host);
			}
		}
		else if (codigo == 24)
		{
			char expulsado[20];
			char expulsion[20];
			int socketInvitado;
			
			p = strtok(NULL, "/");
			strcpy(host, p);
			p = strtok(NULL, "/");
			strcpy(expulsado, p);
			sprintf(expulsion, "24/%s/%s", host, expulsado);
			
			JugadoresEnPartida(&lista_Partidas, sockets_receptores, host, infoJugadoresPartida);
			EliminarJugadorPartida(&lista_Partidas, expulsado, host);
			
			p = strtok(sockets_receptores, "/");
			while (p != NULL)
			{
				socketUsuario = atoi(p);
				if (socketUsuario != sock_conn)
					write(socketUsuario, expulsion, strlen(expulsion));
				p = strtok(NULL, "/");
			}
			
			strcpy(respuesta, expulsion);
		}
		else if (codigo == 25)
		{
			
		}
		else if (codigo == 26)
		{
			p = strtok(NULL, "/");
			strcpy(host, p);
			
			sprintf(mensaje, "26/%s", host);
			
			pthread_mutex_lock(&mutex);
			int partida = BuscarPartidaHost(&lista_Partidas,host);
			if (partida != -1)
			{
				JugadoresEnPartida(&lista_Partidas, sockets_receptores, host, infoJugadoresPartida);
				EliminarPartida(&lista_Partidas,host);
				p = strtok(sockets_receptores, "/");
				while (p != NULL)
				{
					socketUsuario = atoi(p);
					if (socketUsuario != sock_conn)
						write(socketUsuario, mensaje, strlen(mensaje));
					p = strtok(NULL, "/");
				}
				strcpy(respuesta, mensaje);
			}
			pthread_mutex_unlock(&mutex);
		}
		else if (codigo == 27)
		{
			//Jugador envia un mensaje por el chat
			char expulsion[20];
			char mensajechat[200];
			char chat[200];
			char jugador[20];
			
			p = strtok(NULL, "/");
			strcpy(host, p);
			p = strtok(NULL, "/");
			strcpy(jugador, p);
			p = strtok(NULL, "/");
			strcpy(chat, p);
			sprintf(mensajechat, "27/%s/%s/%s", host, jugador, chat);
			
			JugadoresEnPartida(&lista_Partidas, sockets_receptores, host, infoJugadoresPartida);
			p = strtok(sockets_receptores, "/");
			while (p != NULL)
			{
				socketUsuario = atoi(p);
				if (socketUsuario != sock_conn)
					write(socketUsuario, mensajechat, strlen(mensajechat));
				p = strtok(NULL, "/");
			}
			strcpy(respuesta, mensajechat);
		}
		else if (codigo == 28)
		{
			char coloresJugadoresPartida[50];
			char player[20];
			int IDcolor;
			
			p = strtok(NULL, "/");
			strcpy(host, p);
			p = strtok(NULL, "/");
			strcpy(player, p);
			p = strtok(NULL, "/");
			IDcolor = atoi(p);
			
			int partidaIndex = BuscarPartidaHost(&lista_Partidas, host);
			int jugadorIndex = BuscarUsuarioPartida(&lista_Partidas, player, partidaIndex);
			lista_Partidas.partidas[partidaIndex].colores[jugadorIndex] = IDcolor;
			ColoresJugadoresEnPartida(&lista_Partidas, host, coloresJugadoresPartida);
			// Send solution cards info to all players
			char mensajeColor[50];
			
			JugadoresEnPartida(&lista_Partidas, sockets_receptores, host, infoJugadoresPartida);
			p = strtok(sockets_receptores, "/");
			sprintf(mensajeColor, "28/%s/%s/%d", host, player, IDcolor);
			while (p != NULL)
			{
				socketUsuario = atoi(p);
				if (socketUsuario != sock_conn)
					write(socketUsuario, mensajeColor, strlen(mensajeColor));
				p = strtok(NULL, "/");
			}
			
			// Once all cards info is sent, send message to start turn to the host
			sprintf(respuesta, "");
		}
		else if (codigo == 40)
		{
			char mensajeiniciopartida[50];
			p = strtok(NULL, "/");
			strcpy(host, p);
			
			int partidaIndex = BuscarPartidaHost(&lista_Partidas, host);
			actualizarEstadoPartida(&lista_Conectados, &lista_Partidas, partidaIndex, 1);
			
			JugadoresEnPartida(&lista_Partidas, sockets_receptores, host, infoJugadoresPartida);
			p = strtok(sockets_receptores, "/");
			sprintf(mensajeiniciopartida, "40/%s", host);
			while (p != NULL)
			{
				socketUsuario = atoi(p);
				write(socketUsuario, mensajeiniciopartida, strlen(mensajeiniciopartida));
				p = strtok(NULL, "/");
			}
			strcpy(respuesta, "");
		}
		else if (codigo == 42)
		{
			p = strtok(NULL, "/");
			strcpy(host, p);
			p = strtok(NULL, "/");
			strcpy(userName, p);
			sprintf(mensaje,"41/%s",host);
			
			int partidaIndex = BuscarPartidaHost(&lista_Partidas,host);
			int jugadorIndex = BuscarUsuarioPartida(&lista_Partidas,userName,partidaIndex);
			
			// Check if player is last player in game, next turn is for host, else next turn is for next player
			if (lista_Partidas.partidas[partidaIndex].numJugadores == jugadorIndex + 1)
			{
				socketUsuario = lista_Partidas.partidas[partidaIndex].jugadores[0].socket;
				write(socketUsuario, mensaje, strlen(mensaje));
			}
			else
			{
				socketUsuario = lista_Partidas.partidas[partidaIndex].jugadores[jugadorIndex+1].socket;
				write(socketUsuario, mensaje, strlen(mensaje));
			}
		}
		else if (codigo == 43)
		{
			char coloresJugadoresPartida[20];
			char cardsSol[20];
			char cardsPlayers[100];
			
			p = strtok(NULL, "/");
			strcpy(host, p);
			p = strtok(NULL, "/");
			strcpy(cardsSol, p);
			p = strtok(NULL, "/");
			strcpy(cardsPlayers, p);
			
			// Send solution cards info to all players
			char mensajeCardsSol[50];
			
			JugadoresEnPartida(&lista_Partidas, sockets_receptores, host, infoJugadoresPartida);
			ColoresJugadoresEnPartida(&lista_Partidas, host, coloresJugadoresPartida);
			p = strtok(sockets_receptores, "/");
			sprintf(mensajeCardsSol, "44/%s/%s/%s/%s/%s", host, cardsSol, infoJugadoresPartida, coloresJugadoresPartida, cardsPlayers);
			while (p != NULL)
			{
				socketUsuario = atoi(p);
				if (socketUsuario != sock_conn)
					write(socketUsuario, mensajeCardsSol, strlen(mensajeCardsSol));
				p = strtok(NULL, "/");
			}
			
			// Once all cards info is sent, send message to start turn to the host
			sprintf(respuesta, "41/%s/%s", host, coloresJugadoresPartida);
		}
		else if (codigo == 45)
		{
			char mensajePosition[100];
			char prePosition[20];
			char position[20];
			
			p = strtok(NULL, "/");
			strcpy(host, p);
			p = strtok(NULL, "/");
			strcpy(userName, p);
			p = strtok(NULL, "/");
			strcpy(prePosition, p);
			p = strtok(NULL, "/");
			strcpy(position, p);
			
			JugadoresEnPartida(&lista_Partidas, sockets_receptores, host, infoJugadoresPartida);
			p = strtok(sockets_receptores, "/");
			sprintf(mensajePosition, "45/%s/%s/%s/%s", host, userName, prePosition, position);
			while (p != NULL)
			{
				socketUsuario = atoi(p);
				if (socketUsuario != sock_conn){
					write(socketUsuario, mensajePosition, strlen(mensajePosition));
					printf("Sent message position: %s \n",mensajePosition);
				}
				p = strtok(NULL, "/");
			}
			
			strcpy(respuesta, "");
		}
		else if (codigo == 46)
		{
			char cardsGuess[20];
			char mensajeGuess[200];
			
			p = strtok(NULL, "/");
			strcpy(host, p);
			p = strtok(NULL, "/");
			strcpy(userName, p);
			p = strtok(NULL, "/");
			strcpy(cardsGuess, p);
			sprintf(mensajeGuess, "46/%s/%s/%s", host, userName, cardsGuess);
			
			JugadoresEnPartida(&lista_Partidas, sockets_receptores, host, infoJugadoresPartida);
			p = strtok(sockets_receptores, "/");
			while (p != NULL)
			{
				socketUsuario = atoi(p);
				if (socketUsuario != sock_conn){
					write(socketUsuario, mensajeGuess, strlen(mensajeGuess));
					printf("Sent message guess: %s \n",mensajeGuess);
				}
				p = strtok(NULL, "/");
			}
			strcpy(respuesta, "");
		}
		else if (codigo == 47) // 47/Host/JugX/JugY/Suspect.Weapon.Room/Respuesta
		{
			int guessResponse;
			char cardsGuess[20];
			char playerGuess[20];
			char playerResponse[20];
			char mensajeGuess[200];
			
			p = strtok(NULL, "/");
			strcpy(host, p);
			p = strtok(NULL, "/");
			strcpy(playerGuess, p);
			p = strtok(NULL, "/");
			strcpy(playerResponse, p);
			p = strtok(NULL, "/");
			guessResponse = atoi(p);
			
			// If guess response is not -1, the guess has been answered -> end guess iterations
			if (guessResponse != -1)
			{
				sprintf(mensajeGuess, "48/%s/%s/%s/%d", host, playerGuess, playerResponse, guessResponse);
				
				JugadoresEnPartida(&lista_Partidas, sockets_receptores, host, infoJugadoresPartida);
				p = strtok(sockets_receptores, "/");
				while (p != NULL)
				{
					socketUsuario = atoi(p);
					write(socketUsuario, mensajeGuess, strlen(mensajeGuess));
					p = strtok(NULL, "/");
				}
				strcpy(respuesta, "");
			}
			else
			{
				int partidaIndex = BuscarPartidaHost(&lista_Partidas,host);
				int jugadorIndex = BuscarUsuarioPartida(&lista_Partidas,playerResponse,partidaIndex);
				
				// Check if next player to guess is the player who guessed  partida.IndexOf(playerGuess) + 1 == partida.Count && partida.IndexOf(userName) == 0
				if ( (strcmp(lista_Partidas.partidas[partidaIndex].jugadores[jugadorIndex+1].userName,playerGuess) == 0) 
					|| (jugadorIndex + 1 == lista_Partidas.partidas[partidaIndex].numJugadores && (strcmp(lista_Partidas.partidas[partidaIndex].jugadores[0].userName,playerGuess) == 0)) )
				{
					sprintf(mensajeGuess, "48/%s/%s/%s/%d", host, playerGuess, playerResponse, -1);
					
					JugadoresEnPartida(&lista_Partidas, sockets_receptores, host, infoJugadoresPartida);
					p = strtok(sockets_receptores, "/");
					while (p != NULL)
					{
						socketUsuario = atoi(p);
						write(socketUsuario, mensajeGuess, strlen(mensajeGuess));
						p = strtok(NULL, "/");
					}
					strcpy(respuesta, "");
				}
				else
				{
					sprintf(mensajeGuess, "47/%s/%s", host, playerGuess);
					
					if (lista_Partidas.partidas[partidaIndex].numJugadores == jugadorIndex + 1)
					{
						socketUsuario = lista_Partidas.partidas[partidaIndex].jugadores[0].socket;
						write(socketUsuario, mensajeGuess, strlen(mensajeGuess));
					}
					else
					{
						socketUsuario = lista_Partidas.partidas[partidaIndex].jugadores[jugadorIndex+1].socket;
						write(socketUsuario, mensajeGuess, strlen(mensajeGuess));
					}
				}
			}
			
			strcpy(respuesta, "");
		}
		else if (codigo == 48)
		{
			char playerGuess[20];
			char mensajeGuess[200];
			
			p = strtok(NULL, "/");
			strcpy(host, p);
			p = strtok(NULL, "/");
			strcpy(userName, p);
			p = strtok(NULL, "/");
			strcpy(playerGuess, p);
			sprintf(mensajeGuess, "46/%s/%s/%s", host, userName, playerGuess);
			
			JugadoresEnPartida(&lista_Partidas, sockets_receptores, host, infoJugadoresPartida);
			p = strtok(sockets_receptores, "/");
			while (p != NULL)
			{
				socketUsuario = atoi(p);
				if (socketUsuario != sock_conn){
					write(socketUsuario, mensajeGuess, strlen(mensajeGuess));
					printf("Sent message guess: %s \n",mensajeGuess);
				}
				p = strtok(NULL, "/");
			}
			strcpy(respuesta, "");
		}
		else if (codigo == 49)
		{
			char playerSolve[20];
			char mensajeSolve[200];
			
			p = strtok(NULL, "/");
			strcpy(host, p);
			p = strtok(NULL, "/");
			strcpy(playerSolve, p);
			sprintf(mensajeSolve, "49/%s/%s", host, playerSolve);
			
			JugadoresEnPartida(&lista_Partidas, sockets_receptores, host, infoJugadoresPartida);
			p = strtok(sockets_receptores, "/");
			while (p != NULL)
			{
				socketUsuario = atoi(p);
				if (socketUsuario != sock_conn){
					write(socketUsuario, mensajeSolve, strlen(mensajeSolve));
					printf("Sent message solve: %s \n",mensajeSolve);
				}
				p = strtok(NULL, "/");
			}
			strcpy(respuesta, "");
		}
		else if (codigo == 50)
		{
			char playerSolve[20];
			char mensajeSolve[200];
			char cardsSolve[20];
			
			p = strtok(NULL, "/");
			strcpy(host, p);
			p = strtok(NULL, "/");
			strcpy(playerSolve, p);
			p = strtok(NULL, "/");
			strcpy(cardsSolve, p);
			
			sprintf(mensajeSolve, "50/%s/%s/%s", host, playerSolve, cardsSolve);
			
			JugadoresEnPartida(&lista_Partidas, sockets_receptores, host, infoJugadoresPartida);
			p = strtok(sockets_receptores, "/");
			while (p != NULL)
			{
				socketUsuario = atoi(p);
				if (socketUsuario != sock_conn){
					write(socketUsuario, mensajeSolve, strlen(mensajeSolve));
					printf("Sent message change solve cards: %s \n",mensajeSolve);
				}
				p = strtok(NULL, "/");
			}
			strcpy(respuesta, "");
		}
		else if (codigo == 51)
		{
			char playerSolve[20];
			int solucionsolve;
			char mensajesolucionsolve[200];
			
			p = strtok(NULL, "/");
			strcpy(host, p);
			p = strtok(NULL, "/");
			strcpy(playerSolve, p);
			p = strtok(NULL, "/");
			solucionsolve = atoi(p);
			
			sprintf(mensajesolucionsolve, "51/%s/%s/%d", host, playerSolve, solucionsolve);
			
			JugadoresEnPartida(&lista_Partidas, sockets_receptores, host, infoJugadoresPartida);
			p = strtok(sockets_receptores, "/");
			while (p != NULL)
			{
				socketUsuario = atoi(p);
				if (socketUsuario != sock_conn){
					write(socketUsuario, mensajesolucionsolve, strlen(mensajesolucionsolve));
					printf("Sent message change solve cards: %s \n",mensajesolucionsolve);
				}
				p = strtok(NULL, "/");
			}
			strcpy(respuesta, "");
		}
		if ((codigo != 0) && (codigo != 4) && (codigo != 40) && (codigo != 42) && (codigo != 45) && (codigo != 47) && (codigo != 48) && (codigo != 49) && (codigo != 50))
		{
			printf("Respuesta: %s\n", respuesta);
			// Enviamos respuesta
			write(sock_conn, respuesta, strlen(respuesta));		// sock_conn es el socket del host
		}
		if (codigo == 2)
		{
			// Disconnection notification already handled in codigo 0 conditional
			if (BuscarConectado(&lista_Conectados,userName) != -1) {
				consultaConectados(&lista_Conectados, conectados);
				sprintf(notificacion, "10/%s",conectados);
				
				int j;
				for (j = 0; j < 100; j++)
					if (sockets[j] != -1)
						write(sockets[j], notificacion, strlen(notificacion));
			}
		}
		/* else if (codigo == 40)
		{
			consultaConectados(&lista_Conectados, conectados);
			sprintf(notificacion, "10/%s",conectados);
			
			int j;
			for (j = 0; j < 100; j++)
				if (sockets[j] != -1)
					write(sockets[j], notificacion, strlen(notificacion));
		} */
	}
	// Se acabo el servicio para este cliente
	// Liberar la posicion de su socket del vector de sockets (cambiando el valor a -1)
	for (int n=0; n<100; n++)
		if (sockets[n] == sock_conn)
	{
			sockets[n] = -1;
			break;
	}
	close(sock_conn);
}

int main(int argc, char* argv[])
{
	// Set all position in sockets to -1 so they will be replaced by real used sockets later on
	for (int i = 0; i < sizeof(sockets) / sizeof(sockets[0]); i++) {
		sockets[i] = -1;
	}
	
	int sock_conn, sock_listen, ret;
	struct sockaddr_in serv_adr;
	if ((sock_listen = socket(AF_INET, SOCK_STREAM, 0)) < 0)
		printf("Error creant socket");
	// Fem el bind al port

	//int puerto = 50075;  //50075-50090 for Shiva
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
				
		int n = 0;
		for (n=0; n<100; n++)
			if (sockets[n] == -1)
			{
				sockets[n] = sock_conn;
				break;
			}
			
		/*	Code to write all sockets (debbuging) 
		printf("Sockets: \n");
		for (int i = 0; i < sizeof(sockets) / sizeof(sockets[0]); i++) {
			printf("%d ", sockets[i]);
		}
		printf("\n"); */
		
		if (n != 100)
			pthread_create(&thread, NULL, AtenderCliente, &sockets[n]);
	}
	return 0;
}


