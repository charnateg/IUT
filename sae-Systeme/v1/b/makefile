MKDIR_P ?= mkdir -p

#nom de l'executable
TARGET_EXEC ?= Server

#dossier des .c
SRC_DIRS ?= ./src
#dossier des .h
INCLUDE_DIRS ?= ./includes
#dossier des .o
BUILD_DIR ?= ./build
#dossier de l'executable
TARGET_DIR ?= ./bin

#tableau contenant les .c
SRCS := $(shell find $(SRC_DIRS) -name "*.c")
#tableau contenant les .o
OBJS := $(SRCS:%.c=$(BUILD_DIR)/%.o)
#tableau contenant les .d
DEPS := $(OBJS:.o=.d)

#permet de ne pas avoir a définir les chemins d'accès
VPATH := $(SRC_DIRS)
vpath %.h $(INCLUDE_DIRS)
vpath %.o $(BUILD_DIR)

#pour faire un raccourcis des includes pour le compilateur
INC_DIRS := $(shell find $(INCLUDE_DIRS) -type d)
INC_FLAGS := $(addprefix -I,$(INC_DIRS))

#options du gcc
CFLAGS ?= $(INC_FLAGS) -MMD -MP -O3 -Wall -Wextra -Wno-unused-parameter

#mets les .c en .o
$(TARGET_DIR)/$(TARGET_EXEC): $(OBJS)
	$(MKDIR_P) $(TARGET_DIR)
	$(CC) $(OBJS) -o $@ $(LDFLAGS)

#compile le tout
$(BUILD_DIR)/%.o: %.c
	$(MKDIR_P) $(dir $@)
	$(CC) $(CFLAGS) -c $< -o $@


#permet d'atteindre les target même si un fichier du meme nom existe
.PHONY: valgrind clean mrproper

#autres target
valgrind:
	valgrind --tool=memcheck --leak-check=full --track-origins=yes ./exec/

clean:
	$(RM) -r $(BUILD_DIR)

mrproper: clean
	$(RM) -r $(TARGET_DIR)


-include $(DEPS)