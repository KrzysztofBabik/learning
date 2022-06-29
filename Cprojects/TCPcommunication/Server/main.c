#include <stdio.h>
#include <stdlib.h>
#include <winsock2.h>

#define BUFLEN 1500
#define PORT 7777

void server_tcp()

{
    SOCKET s,sl;
    struct sockaddr_in sa_server ;
    int recv_len; //i
    char message[BUFLEN];

    printf( "Create socket...\n");
    sl = socket(AF_INET, SOCK_STREAM, IPPROTO_TCP);
    if(sl==INVALID_SOCKET)
    {
        printf("Failed...");
        return;
    }
    printf("OK \n");
    sa_server.sin_family = AF_INET;
    sa_server.sin_addr.s_addr = INADDR_ANY;
    sa_server.sin_port = htons( PORT );

    printf("Bind socket...\n");
    if( bind(sl,(struct sockaddr *)&sa_server, sizeof(sa_server))==SOCKET_ERROR)
    {
         printf("Failed... \n");
         return;
    }
     printf("OK \n");

     listen(sl,3);

     printf("Waiting for connection ... \n");

     s=accept(sl,NULL,NULL);
     if(s==INVALID_SOCKET)
     {
          printf("Failed \n");

     }
      printf("ok \n");


     while(1)
     {
          printf("Waiting for a message... \n");
          if((recv_len=recv(s,message,BUFLEN,0))<=0)
          {
               printf("Failed... \n");
               break;
          }
          message[recv_len]=0;
           printf("OK \n Data:%s \n", message);

           if(strcmp(message,"Q")==0)
           {
               closesocket(s);
               break;
           }


           printf("Sending a message... \n");

           if(send(s,message,strlen(message),0)<0)
           {
               printf("Failed \n");
               break;
           }
           printf("OK! \n");
     }
    closesocket(s);
}


int main()
{
    WSADATA wsaData;

    printf("\n Inicializing Winsock...");
    if (WSAStartup(MAKEWORD(2,2),&wsaData)== NO_ERROR)
    {
        printf(" \n  Inicializing complete! \n");
        server_tcp();
        WSACleanup();

    }
    else
    {
        printf(" \n Failed! \n");
    }
    return 0;
}
