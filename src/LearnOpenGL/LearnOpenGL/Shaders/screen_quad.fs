#version 430 core
out vec4 FragColor;

in vec2 TexCoords;

#define KERNEL_SIZE 9

uniform sampler2D screenTexture;

const float offset = 1.0 / 300.0;

void main()
{
	vec2 offsets[KERNEL_SIZE] = vec2[](
		vec2(-offset, offset),
		vec2(0, offset),
		vec2(offset, offset),
		vec2(-offset, 0),
		vec2(0, 0),
		vec2(offset, 0),
		vec2(-offset, -offset),
		vec2(0, -offset),
		vec2(offset, -offset)
	);

	float kernel[KERNEL_SIZE] = float[](
		1.0, 2.0, 1.0,
		2.0, 4.0, 2.0,
		1.0, 2.0, 1.0
	);

	float kernel_sum = 16.0;

	vec3 color = vec3(0.0);
	for (int i = 0; i < KERNEL_SIZE; ++i)
	{
		color += (kernel[i] / kernel_sum) * texture(screenTexture, TexCoords.st + offsets[i]).rgb;
	}

	FragColor = vec4(color, 1.0);
	
}