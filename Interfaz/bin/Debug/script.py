import sys

def mostrar_contenido_hexadecimal(ruta_archivo,mensaje_hex):
    with open(ruta_archivo, 'rb') as archivo:
        contenido = archivo.read()
        contenido_hex = contenido.hex()
        for i in range(0, len(contenido_hex), 32):
            linea_hex = contenido_hex[i:i+32]
            linea_bytes = ' '.join([linea_hex[j:j+2] for j in range(0, len(linea_hex), 2)])
    contenido_completo = contenido + mensaje_hex
    with open('voice.wav', 'wb') as archivo:
        archivo.write(contenido_completo)


def encriptar(cadena):
    mensaje_encriptado = ""
    for c in cadena:
        ascii_value = ord(c)
        encrypted_ascii_value = (ascii_value + 5) % 256
        encrypted_char = chr(encrypted_ascii_value)
        mensaje_encriptado += encrypted_char
    return mensaje_encriptado



def main():
    argumentos = sys.argv[1:]
    ruta_audio = sys.argv[1]  # Reemplaza con la ruta de tu archivo
    textoaencriptar = sys.argv[2]
    print(ruta_audio)
    print(textoaencriptar)
    mensaje_encriptado = encriptar(textoaencriptar)
    mensaje_encriptado_hex = mensaje_encriptado.encode().hex()
    mensaje_encriptado_bytes = bytes.fromhex(mensaje_encriptado_hex)
    print(mensaje_encriptado)
    print(mensaje_encriptado_hex)
    mostrar_contenido_hexadecimal(ruta_audio,mensaje_encriptado_bytes)
    #mostrar_contenido_hexadecimal(ruta_audio)

if __name__ == "__main__":
    main()