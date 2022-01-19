export class User {

    id: string;
    firstName: string; 
    lastName: string;
    role: string;
    address: string;
    imageUrl: string;
    isCollapsed: boolean = true;

    constructor(id: string, firstName: string, lastName: string, role: string, 
        address: string, imageUrl: string, isCollapsed: boolean){
            
            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
            this.role = role;
            this.address = address;
            this.imageUrl = imageUrl;
            this.isCollapsed = isCollapsed;
        }
}