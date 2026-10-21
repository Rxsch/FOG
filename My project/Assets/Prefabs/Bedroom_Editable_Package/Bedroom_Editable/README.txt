CUARTO EDITABLE

ARCHIVOS
- Bedroom_Editable.blend: abre este archivo en Blender 4.5 o posterior.
  Textura de madera incluida dentro del archivo.
- bedroom_blankv2.fbx: modelo exportado para Unity, con textura incrustada.
- Textures/Oak_BaseColor.png: textura de color de madera.
- Bedroom_Preview.png: vista previa renderizada en Blender.

CAMBIOS
El modelo original contenía 161 caras en un único objeto y un solo material.
Ahora hay 20 objetos seleccionables: Floor, Ceiling, ocho tramos de pared,
Door, Door_Frame, Skirting_Boards, Crown_Moulding y seis piezas de ventana.
Los cristales son Window_Glass_Left y Window_Glass_Right.
Las paredes usan un acabado claro de yeso; el suelo y la puerta, madera de roble.
El suelo y el techo siguen el contorno de las paredes.
Se agregó grosor a las paredes y a los cristales, conservando las caras interiores.
Los orígenes de los objetos están centrados para facilitar su edición.

EN BLENDER
1. Abre Bedroom_Editable.blend.
2. En Object Mode, selecciona Floor, una pared o un cristal por separado.
3. Usa Material Preview o Rendered para ver materiales y transparencia.
4. Para mirar desde arriba, oculta Ceiling con el icono del ojo en el Outliner.
La colección Preview contiene luces y cámara de presentación; no se exporta al FBX.
Las paredes comparten material entre sí, pero no con el suelo. Para cambiar el
material de una sola pared, haz una copia de su material (botón del número de usuarios).

EN UNITY (URP)
Importa el FBX y la carpeta Textures en una carpeta nueva de Assets.
Expande la instancia del modelo en Hierarchy para seleccionar sus partes.
En el Inspector del FBX, pestaña Materials, puedes usar Extract Materials.
Si hace falta, asigna Oak_BaseColor.png al Base Map del suelo y de la puerta.

Para el material de ambos cristales:
- Shader: Universal Render Pipeline/Lit
- Surface Type: Transparent
- Blending Mode: Alpha
- Base Map: color ligeramente azulado, Alpha 0.18 (aproximadamente 46/255)
- Smoothness: 0.9
- Metallic: 0
- Alpha Clipping: desactivado
Los paneles tienen grosor y caras por ambos lados.
La transparencia de Blender y la configuración de shaders de Unity no son
idénticas; revisa estas opciones después de importar.
Referencia oficial: https://docs.unity3d.com/6000.0/Documentation/Manual/urp/lit-shader.html

VERIFICACIÓN
Se renderizó en Blender y se volvió a importar el FBX en una escena vacía:
20 mallas independientes, textura de suelo enlazada y alpha del cristal menor a 0.3.
No se probó dentro de tu proyecto Unity. La iluminación de la vista previa es
solo de presentación. El relieve procedural del yeso y de la madera pertenece
al material de Blender; el FBX lleva colores, textura de madera y valores básicos.

TEXTURA DE MADERA
Creada con la herramienta de generación de imágenes integrada.
Prompt: Seamless square albedo texture for a 3D game room wood floor. Flat
orthographic surface scan of aged medium brown oak planks, six parallel
horizontal rows, staggered end joints, fine oak grain, small knots, mild wear,
matte unvarnished wood. Even diffuse lighting, no perspective, no objects,
no text, tileable edges.
