//KRZYSZTOF BABIK 12AL1

#include <stdio.h>
#include <stdlib.h>
#include <winsock2.h>

#define BUFLEN 10000
#define IP "149.156.153.157"


void client_www()
{
    struct sockaddr_in sa_other;
    int s;
    char message[BUFLEN];
    int recv_len;

    printf("\nCreate socket...\n");
    s = socket(AF_INET, SOCK_STREAM, IPPROTO_TCP);
    if(s == INVALID_SOCKET)
    {
        printf("Failed\n");
        return;
    }
    printf("OK\n");

    sa_other.sin_family = AF_INET;
    sa_other.sin_port = htons(80);
    sa_other.sin_addr.S_un.S_addr = inet_addr(IP);

    printf("Connect to remote server...");
    if(connect(s, (struct sockaddr *)&sa_other, sizeof(sa_other)) < 0)
    {
        printf("Failed\n");
        return;
    }
    printf("OK\n");

    strcpy(message, "GET / HTTP/1.0\r\n\r\n");
    printf("sending message: %s\n ...", message);
    if( send(s, message, strlen(message), 0) < 0)
    {
        printf("\nFailed.\n");
        return;
    }
    printf("OK\n");

    printf("Waiting for message...");
    if((recv_len = recv(s, message, BUFLEN, 0)) <= 0)
    {
        printf("\nFailed\n");
        return;
    }
    printf("OK\n");

    message[recv_len] = 0;
    printf("----------------------TEXT----------------\n%s\n", message);

    return;
}

int main()
{
    WSADATA wsaData;

    printf("\nInitialising Winsock...");
    if (WSAStartup (MAKEWORD(2,2), &wsaData) == NO_ERROR)\
    {
        printf("OK\n");

        client_www();

        WSACleanup();
    }
    else
    {
        printf("Failed.\n");
    }

    return 0;
}
