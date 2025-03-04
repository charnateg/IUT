MKDIR_P ?= mkdir -p

# Noms des exécutables
TARGET_EXEC ?= V2a

# Dossiers pour les sources, includes, objets, et exécutables
SRC_DIRS ?= ./src
INCLUDE_DIRS ?= ./includes
BUILD_DIR ?= ./build
TARGET_DIR ?= ./bin

# Sources spécifiques pour l'exécutable principal
MAIN_SRCS := $(SRC_DIRS)/V2a.c $(SRC_DIRS)/fonctions.c

# Objets pour l'exécutable principal
MAIN_OBJS := $(MAIN_SRCS:$(SRC_DIRS)/%.c=$(BUILD_DIR)/%.o)

# Options de compilation
INC_DIRS := $(shell find $(INCLUDE_DIRS) -type d)
INC_FLAGS := $(addprefix -I,$(INC_DIRS))
CFLAGS ?= $(INC_FLAGS) -O3 -Wall -Wextra -Wno-unused-parameter

# Compilation du programme principal (V2a)
$(TARGET_DIR)/$(TARGET_EXEC): $(MAIN_OBJS)
	$(MKDIR_P) $(TARGET_DIR)
	$(CC) $(MAIN_OBJS) -o $@ $(LDFLAGS)

# Compilation des objets pour les sources
$(BUILD_DIR)/%.o: $(SRC_DIRS)/%.c
	$(MKDIR_P) $(dir $@)
	$(CC) $(CFLAGS) -c $< -o $@

# Compilation de estPresent.c
bin/estPresent: src/estPresent.c
	gcc -o bin/estPresent src/estPresent.c

# Compilation de estPresent.c
bin/simulerCombat: src/simulerCombat.c
	gcc -o bin/simulerCombat src/simulerCombat.c

# Compilation de estPresent.c
bin/lancerCombat: src/lancerCombat.c
	gcc -o bin/lancerCombat src/lancerCombat.c

# Règle par défaut pour construire l'exécutable principal
.PHONY: all
all: $(TARGET_DIR)/$(TARGET_EXEC) bin/estPresent bin/simulerCombat bin/lancerCombat

# Autres règles
.PHONY: valgrind clean mrproper

valgrind:
	valgrind --tool=memcheck --leak-check=full --track-origins=yes $(TARGET_DIR)/$(TARGET_EXEC)

clean:
	$(RM) -r $(BUILD_DIR)

mrproper: clean
	$(RM) -r $(TARGET_DIR)
