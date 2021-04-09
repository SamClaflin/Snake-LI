CC = csc
EXEC = mono
TARGET =  Main.exe
SRC = src/*.cs

all: $(TARGET)
$(TARGET): $(SRC) 
	$(CC) $(SRC)

run: $(TARGET)
	$(EXEC) $(TARGET)

clean:
	rm $(TARGET)

