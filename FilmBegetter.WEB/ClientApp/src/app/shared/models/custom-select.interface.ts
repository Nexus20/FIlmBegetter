export interface ICustomSelectItem {
    text: string,
    value: string,
}

export interface ICustomSelect {
    icon?: string,
    title: string,
    elements: ICustomSelectItem[]
}