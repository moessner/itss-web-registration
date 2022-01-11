export class User {

    id: string;
    firstName: string; 
    lastName: string;
    role: string;
    address: string;
    image: string;
    isCollapsed: boolean;

    constructor(id: string, firstName: string, lastName: string, role: string, 
        address: string, image: string, isCollapsed: boolean){
            
            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
            this.role = role;
            this.address = address;
            this.image = image;
            this.isCollapsed = isCollapsed;
        }
}