import sys
def mostrar_mensaje_encriptado(ruta_archivo,ruta_archivo_encriptado):
	with open(ruta_archivo,'rb') as archivo1:
		contenido1 = archivo1.read()
	with open(ruta_archivo_encriptado,'rb') as archivo2:
		contenido2 = archivo2.read()
	contenido_hex1 = contenido1.hex()
	contenido_hex2 = contenido2.hex()
	str1 = str(contenido_hex1)
	str2 = str(contenido_hex2)
	if contenido1 in contenido2:
		parte = str2[len(str1):]
		bytes_hex = bytes.fromhex(parte)
		cadena_ascii = bytes_hex.decode('ascii')
		print(cadena_ascii)
	else:
		print("No")
def main():
	ruta_audio = sys.argv[1]  # Reemplaza con la ruta de tu archivo
	ruta_audio_encriptado = sys.argv[2]
	mostrar_mensaje_encriptado(ruta_audio,ruta_audio_encriptado)

if __name__ == "__main__":
    main()