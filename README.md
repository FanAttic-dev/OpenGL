# TODO

- [ ] go through advenced methods
- [ ] look up advanced data
- [ ] setup lighting for a model
- [ ] go thorugh PV227



# NOTES

### Model loading

- **A model** is composed of one or more meshes
- **A mesh** is a sub-model, shape that a model consists of



### Preventing Z-fighting

- avoid coplanar faces in the scene
  - always put a small, not noticeable gap between two faces
- set the **near plane as far ass possible**
- use higher precision depth buffer
  - 32 bits instead of 24 bits



### Stencil testing

- depth testing -> fragment shader -> stencil testing

  ```c++
  // turn on stencil test
  glEnable(GL_STENCIL_TEST);
  glClear(GL_STENCIL_BUFFER_BIT); 
  
  // allow writing to the stencil buffer
  glStencilMask(0xFF);
  // disable writing to the stencil buffer
  glStencilMask(0x00);
  
  // setup behavior if stencil/depth test pass or fail
  glStencilOp(GL_KEEP, GL_KEEP, GL_REPLACE);  
    
  // setup reference value and comparison operator
  glStencilFunc(GL_ALWAYS, 1, 0xFF); 
  ```

- **Object highlighting**

  1. enable stencil test and allow writing to the stencil buffer

  2. draw all the objects using the normal shader and writing to the stencil buffer

     ```c++
     glStencilOp(GL_KEEP, GL_KEEP, GL_REPLACE);
     glStencilFunc(GL_ALWAYS, 1, 0xFF);
     glStencilMask(0xFF);
     
     normalShader.use();
     DrawObjects();
     ```

  3. disable depth test and writing to the stencil buffer and render the highlight color using a simple shader only where **the stencil values are not equal to 1**

     ```c++
     glDisable(GL_DEPTH_TEST);
     glStencilMask(0x00);
     glStencilFunc(GL_NOTEQUAL, 1, 0xFF);
     
     ScaleUpTheHighlightedObjects();
     highlighShader.use();
     DrawObjects();
     ```

     

### Variables

- Vertex shader
  - `gl_PointSize`
    - particle systems
  - `gl_VertexID`
    - indices or the index of the drawn vertices
- Fragment shader
  - `gl_FragCoord`
    - testing different lighting techniques
  - `gl_FrontFacing`
  - `gl_FragDepth`
    - [0.0, 1.0]
    - implicitly `gl_FragDepth = gl_FragCoord.z`
    - disadvantage: disables *early depth testing*
      - => use `layout (depth_<condition>) out float gl_FragDepth;`
  - 