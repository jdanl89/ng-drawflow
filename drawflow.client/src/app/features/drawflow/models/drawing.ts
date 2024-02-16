export interface Drawing {
  Home: DrawflowSection;
  Other: DrawflowSection;
}

export interface DrawflowSection {
  data: { [key: string]: DrawflowDataElement };
}

export interface DrawflowDataElement {
  id: number;
  name: string | undefined | null;
  data: object;
  class: string | undefined | null;
  html: string | undefined | null;
  typenode: boolean;
  inputs: { [key: string]: DrawflowConnectionsElement };
  outputs: { [key: string]: DrawflowConnectionsElement };
  pos_x: number;
  pos_y: number;
}

export interface DrawflowConnectionsElement {
  connections: DrawflowConnectionElement[];
}

export interface DrawflowConnectionElement {
  node: string;
  input: string | undefined | null;
  output: string | undefined | null;
}
