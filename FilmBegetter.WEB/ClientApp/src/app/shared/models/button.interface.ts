export interface IButton {
    type: 'default' | 'success' | 'danger',
    size: 'default' | 'small', //| 'big'
    text: string,
    disabled: boolean,
    icon?: string,
    href?: string
    unactive?: boolean
}
