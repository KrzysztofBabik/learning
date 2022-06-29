#include <stdio.h>
#include <stdlib.h>
#include <winsock2.h>

#define BUFLEN 1500
#define IP_ADRESS "127.0.0.1"
#define PORT 7777

void klient_tcp()

{
    struct sockaddr_in sa_other ;
    int s,recv_len,i;
    char message[BUFLEN];

    printf( "Create socket...\n");
    s = socket(AF_INET, SOCK_STREAM, IPPROTO_TCP);
    if(s==INVALID_SOCKET)
    {
        printf("Failed...");
        return;
    }
    printf("OK \n");
    sa_other.sin_family = AF_INET;
    sa_other.sin_addr.s_addr = inet_addr( IP_ADRESS );
    sa_other.sin_port = htons( PORT );


     printf("Connecting to server... \n");
     if(connect(s, (struct sockaddr *)&sa_other, sizeof(sa_other))<0)
          {
               printf("Failed...  \n" );
               return;
          }
          printf("Ok  \n" );
     while(1)
     {
          printf("Enter a message... \n");
          gets(message);

          if(strcmp(message,"Q")==0)
          {
               closesocket(s);
               break;
          }

             for(i=0;i<100;++i)
        {
          if (message[i]>='A'&&message[i]<='Z')
        {
            message[i]=message[i]+32;

        }
          else if(message[i]>='a'&&message[i]<='z')
        {
            message[i]=message[i]-32;
        }
        }
          printf("Message sending... \n");
           if(send(s,message,strlen(message),0)<0)
          {
               printf("Failed... \n");
               break;
          }
          printf("Ok \n");

          printf("Waiting for message... \n");
           if((recv_len=recv(s,message,BUFLEN,0))<=0)
          {
             printf("Failed... \n");
               break;
          }
          printf("Ok\n");
     message[recv_len]=0;
     printf("Data: %s \n",message);

     }
    return;
}


int main()
{
    WSADATA wsaData;

    printf("\n Initialization Winsock...");
    if (WSAStartup(MAKEWORD(2,2),&wsaData)== NO_ERROR)
    {
        printf(" \n  Initialization complete! \n");
        klient_tcp();
        WSACleanup();

    }
    else
    {
        printf(" \n Initialization Failed \n");
    }
    return 0;
}
