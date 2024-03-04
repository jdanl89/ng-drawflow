import { HttpClient } from '@angular/common/http';
import {
  Component,
  AfterViewInit,
  OnInit,
  ViewEncapsulation,
} from '@angular/core';
import { Observable, forkJoin } from 'rxjs';
import { NodeElement } from './models/node';
import { Drawing } from './models/drawing';
import Drawflow from 'drawflow';

@Component({
  selector: 'app-drawflow',
  templateUrl: './drawflow.component.html',
  styleUrls: [
    '../../../../node_modules/drawflow/dist/drawflow.min.css',
    './drawflow.component.scss',
  ],
  encapsulation: ViewEncapsulation.None,
})
export class DrawflowComponent implements OnInit, AfterViewInit {
  editor: Drawflow | undefined;
  nodes: NodeElement[] = [];
  drawing: Drawing | undefined;
  mobile_item_selec: string = '';
  mobile_last_move: any = {};
  transform: string = '';

  constructor(private http: HttpClient) {}

  ngOnInit(): void {}

  ngAfterViewInit(): void {
    const nodes = this.getNodes();
    const drawing = this.getDrawing(0);
    forkJoin({ nodes: nodes, drawing: drawing }).subscribe({
      next: (result) => {
        this.nodes = result.nodes;
        this.drawing = result.drawing;
      },
      error: (error) => console.error(error),
      complete: () => this.initDrawFlow(),
    });
  }

  getNodes = (): Observable<NodeElement[]> =>
    this.http.get<NodeElement[]>('/api/modules/nodes');

  getDrawing = (workflowVersionId: number): Observable<Drawing> =>
    this.http.get<Drawing>(
      `/api/workflows/versions/${workflowVersionId}/drawing`,
    );

  initDrawFlow(): void {
    const drawflowHtmlElement: HTMLElement =
      document.getElementById('drawflow')!;

    this.editor = new Drawflow(drawflowHtmlElement);

    this.editor.reroute = true;
    this.editor.curvature = 0.5;
    this.editor.reroute_fix_curvature = true;
    this.editor.reroute_curvature = 0.5;
    this.editor.force_first_input = false;
    this.editor.line_path = 1;
    this.editor.editor_mode = 'edit';

    this.editor.start();
    this.editor.import(this.drawing);

    this.addEditorEvents();
  }

  addEditorEvents(): void {
    this.editor!.on('nodeCreated', function (id) {
      // console.log('Node created ' + id);
    });

    this.editor!.on('nodeRemoved', function (id) {
      // console.log('Node removed ' + id);
    });

    this.editor!.on('nodeSelected', function (id) {
      // console.log('Node selected ' + id);
    });

    this.editor!.on('moduleCreated', function (name) {
      // console.log('Module Created ' + name);
    });

    this.editor!.on('moduleChanged', function (name) {
      // console.log('Module Changed ' + name);
    });

    this.editor!.on('connectionCreated', function (connection) {
      // console.log('Connection created');
      // console.log(connection);
    });

    this.editor!.on('connectionRemoved', function (connection) {
      // console.log('Connection removed');
      // console.log(connection);
    });

    this.editor!.on('mouseMove', function (position) {
      // console.log('Position mouse x:' + position.x + ' y:' + position.y);
    });

    this.editor!.on('nodeMoved', function (id) {
      // console.log('Node moved ' + id);
    });

    this.editor!.on('zoom', function (zoom) {
      // console.log('Zoom level ' + zoom);
    });

    this.editor!.on('translate', function (position) {
      // console.log('Translate x:' + position.x + ' y:' + position.y);
    });

    this.editor!.on('addReroute', function (id) {
      // console.log('Reroute added ' + id);
    });

    this.editor!.on('removeReroute', function (id) {
      // console.log('Reroute removed ' + id);
    });
  }

  onDrag(e: any) {
    if (e.type === 'touchstart') {
      this.mobile_item_selec = e.target
        .closest('.drag-drawflow')
        .getAttribute('data-node');
    } else {
      e.dataTransfer.setData('node', e.target.getAttribute('data-node'));
    }
  }

  onDrop(e: any) {
    if (e.type === 'touchend') {
      var parentdrawflow = document
        .elementFromPoint(
          this.mobile_last_move.touches[0].clientX,
          this.mobile_last_move.touches[0].clientY,
        )!
        .closest('#drawflow');
      if (parentdrawflow != null) {
        this.addNodeToDrawFlow(
          this.mobile_item_selec,
          this.mobile_last_move.touches[0].clientX,
          this.mobile_last_move.touches[0].clientY,
        );
      }
      this.mobile_item_selec = '';
    } else {
      e.preventDefault();
      var data = e.dataTransfer.getData('node');
      this.addNodeToDrawFlow(data, e.clientX, e.clientY);
    }
  }

  addNodeToDrawFlow(name: string, pos_x: number, pos_y: number): boolean {
    if (this.editor!.editor_mode === 'fixed') {
      return false;
    }
    pos_x =
      pos_x *
        (this.editor!.precanvas.clientWidth /
          (this.editor!.precanvas.clientWidth * this.editor!.zoom)) -
      this.editor!.precanvas.getBoundingClientRect().x *
        (this.editor!.precanvas.clientWidth /
          (this.editor!.precanvas.clientWidth * this.editor!.zoom));
    pos_y =
      pos_y *
        (this.editor!.precanvas.clientHeight /
          (this.editor!.precanvas.clientHeight * this.editor!.zoom)) -
      this.editor!.precanvas.getBoundingClientRect().y *
        (this.editor!.precanvas.clientHeight /
          (this.editor!.precanvas.clientHeight * this.editor!.zoom));

    let node: NodeElement = this.nodes.find(
      (n) => n.name.trim().toLowerCase() == name.trim().toLowerCase(),
    )!;

    var html = `<div><div class="title-box"><i class="${node.iconClass}"></i> ${
      node.displayName
    }</div>${node.bodyHtml ?? ''}</div>`;

    this.editor!.addNode(
      node.name,
      node.inputs,
      node.outputs,
      pos_x,
      pos_y,
      node.name,
      node.name,
      html,
      false,
    );

    return true;
  }

  allowDrop(e: any) {
    e.preventDefault();
  }

  onSaveWorkflow() {
    console.log('save button clicked!');
    this.saveWorkflow().subscribe((drawing) => console.log(drawing));
  }

  saveWorkflow(): Observable<Drawing> {
    const workflowId = 0;

    return this.http.post<Drawing>(
      `/api/workflows/${workflowId}/version`,
      this.editor!.export(),
    );
  }

  onClear() {
    this.editor!.clearModuleSelected();
  }

  onLock() {
    this.editor!.editor_mode = 'fixed';
    this.changeMode('lock');
  }

  onUnlock() {
    this.editor!.editor_mode = 'edit';
    this.changeMode('unlock');
  }

  changeMode(option: string) {
    if (option == 'lock') {
      document.getElementById('lock')!.style.display = 'none';
      document.getElementById('unlock')!.style.display = 'block';
    } else {
      document.getElementById('lock')!.style.display = 'block';
      document.getElementById('unlock')!.style.display = 'none';
    }
  }

  changeModule(e: any) {
    var all = document.querySelectorAll('.menu ul li');
    for (var i = 0; i < all.length; i++) {
      all[i].classList.remove('selected');
    }
    e.target.classList.add('selected');
  }

  showpopup(e: any) {
    e.target.closest('.drawflow-node').style.zIndex = '9999';
    e.target.children[0].style.display = 'block';

    this.transform = this.editor!.precanvas.style.transform;
    this.editor!.precanvas.style.transform = '';
    this.editor!.precanvas.style.left = this.editor!.canvas_x + 'px';
    this.editor!.precanvas.style.top = this.editor!.canvas_y + 'px';

    this.editor!.editor_mode = 'fixed';
  }

  closemodal(e: any) {
    e.target.closest('.drawflow-node').style.zIndex = '2';
    e.target.parentElement.parentElement.style.display = 'none';

    this.editor!.precanvas.style.transform = this.transform;
    this.editor!.precanvas.style.left = '0px';
    this.editor!.precanvas.style.top = '0px';
    this.editor!.editor_mode = 'edit';
  }

  onZoomOut() {
    this.editor!.zoom_out();
  }

  onZoomReset() {
    this.editor!.zoom_reset();
  }

  onZoomIn() {
    this.editor!.zoom_in();
  }
}
