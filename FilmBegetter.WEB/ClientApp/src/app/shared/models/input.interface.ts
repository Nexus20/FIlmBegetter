
export interface IInput {
  type: 'default' | 'textarea',//in future using "|" u can add new types
  placeholder: string,
  isdisabled: boolean,
  size?: 'default' | 'small'
  // label: string, // for future updates
  icon?: string,
  error?: string
}
