CC = gcc
CFLAGS = -Wall -Wextra -O2 -Iincludes
OBJS_CLIENT = src/V3_client.o
OBJS_SERVER = src/V3_serveur.o src/jeux.o
TARGET_CLIENT = bin/V3_client
TARGET_SERVER = bin/V3_serveur

all: $(TARGET_CLIENT) $(TARGET_SERVER)

$(TARGET_CLIENT): $(OBJS_CLIENT)
	$(CC) $(CFLAGS) -o $@ $^

$(TARGET_SERVER): $(OBJS_SERVER)
	$(CC) $(CFLAGS) -o $@ $^

%.o: %.c
	$(CC) $(CFLAGS) -c $< -o $@

clean:
	rm -f $(OBJS_CLIENT) $(OBJS_SERVER) $(TARGET_CLIENT) $(TARGET_SERVER)