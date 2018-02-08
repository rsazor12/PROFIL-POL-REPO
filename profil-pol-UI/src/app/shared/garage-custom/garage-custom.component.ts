import { WebglDocumentationExample } from './webgl-documentation-example';
import { WebGlTestClass } from './webgl-test-class';
import { Component, OnInit } from '@angular/core';
import { AfterViewInit } from '@angular/core/src/metadata/lifecycle_hooks';
import * as THREE from 'three';


@Component({
  selector: 'app-garage-custom',
  templateUrl: './garage-custom.component.html',
  styleUrls: ['./garage-custom.component.scss']
})
export class GarageCustomComponent implements AfterViewInit {

  constructor() {
  }

  ngAfterViewInit() {
    let camera, scene, renderer;
    let geometry, material, mesh;

    init();
    animate();

    function init() {
      camera = new THREE.PerspectiveCamera(70, window.innerWidth / window.innerHeight, 0.01, 10);
      camera.position.z = 1;

      scene = new THREE.Scene();

      geometry = new THREE.BoxGeometry(0.2, 0.2, 0.2);


    //   const verticesOfCube = [
    //     -1,-1,-1,    1,-1,-1,    1, 1,-1,    -1, 1,-1,
    //     -1,-1, 1,    1,-1, 1,    1, 1, 1,    -1, 1, 1,
    // ];
    // const indicesOfFaces = [
    //     2,1,0,    0,3,2,
    //     0,4,7,    7,3,0,
    //     0,1,5,    5,4,0,
    //     1,2,6,    6,5,1,
    //     2,3,7,    7,6,2,
    //     4,5,6,    6,7,4
    // ];

    // geometry = new THREE.PolyhedronGeometry(verticesOfCube, indicesOfFaces, 6, 2);




      material = new THREE.MeshNormalMaterial();

      mesh = new THREE.Mesh(geometry, material);
      scene.add(mesh);

      renderer = new THREE.WebGLRenderer({ antialias: true });
      renderer.setSize(window.innerWidth, window.innerHeight);
      document.body.appendChild(renderer.domElement);


      // document.getElementById('glcanvas').appendChild(renderer.domElement);
    }

    function animate() {
      requestAnimationFrame(animate);

      mesh.rotation.x += 0.01;
      mesh.rotation.y += 0.02;

      renderer.render(scene, camera);
    }
  }
//   public webGlTest: WebGlTestClass;
//   public webGlDocumentationExample: WebglDocumentationExample;

//   constructor() {
//     this.webGlTest = new WebGlTestClass();
//     this.webGlDocumentationExample = new WebglDocumentationExample();
//   }


// ngAfterViewInit() {
//   // this.webGlTest.main();
//   this.webGlDocumentationExample.main();
// }



}

