export interface NodeElement {
  id: number;
  name: string;
  iconClass: string | undefined | null;
  displayName: string | undefined | null;
  inputs: number;
  outputs: number;
  data: { [key: string]: any };
  bodyHtml: string | null;
}
