export interface NodeElement {
  id: number;
  name: string;
  iconClass: string;
  displayName: string;
  inputs: number;
  outputs: number;
  data: any;
  bodyHtml: string | null;
}
