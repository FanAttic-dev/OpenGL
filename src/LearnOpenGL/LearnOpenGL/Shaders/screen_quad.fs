#version 430 core
out vec4 FragColor;

in vec2 TexCoords;

uniform bool inversion;
uniform sampler2D screenTexture;

void main()
{
	if (inversion) 
	{
		FragColor = vec4(vec3(1.0 - texture(screenTexture, TexCoords)), 1.0);
	} 
	else
	{
		FragColor = texture(screenTexture, TexCoords);
	}
}