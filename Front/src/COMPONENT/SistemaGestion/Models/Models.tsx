export class Producto{
    id: number = 0;
    description: string = "";
    cost: number = 0;
    salePrice: number= 0;
    stock: number= 0;
    userId: number=0;
    constructor(id: number,
        description: string,
        cost: number,
        salePrice: number,
        stock: number,
        userId: number){
            this.id = id;
            this.description = description;
            this.cost = cost;
            this.salePrice = salePrice;
            this.stock = stock;
            this.userId = userId;
        }
}

export class Usuario{
    id: number = 0;
    password: string = "";
    name: string = "";
    lastName: string = "";
    userName: string ="";
    mail: string ="";
    constructor(id: number = 0,
        name: string = "",
        lastName: string = "",
        userName: string ="",
        password: string = "",
        mail: string =""){
            this.id = id;
            this.password = password;
            this.name = name;
            this.lastName = lastName;
            this.userName = userName;
            this.mail = mail;
        }
}

export class Venta{
    id: number = 0;
    comentarios: string = "";
    constructor(id: number,
        comentarios: string){
            this.id = id;
            this.comentarios = comentarios;
        }
}

export class ProductoVendido{
    id: number = 0;
    stock: string = "";
    idProducto: number = 0;
    idVenta: number = 0;
    constructor(id: number,
        stock: string,
        idProducto: number,
        idVenta: number){
            this.id = id;
            this.stock = stock;
            this.idProducto = idProducto;
            this.idVenta = idVenta;
        }
}
