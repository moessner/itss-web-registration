export class User {

    id: string;
    firstName: string; 
    lastName: string;
    address: string;
    base64Image: string;
    isCollapsed: boolean = true;

    constructor(id: string, firstName: string, lastName: string, 
        address: string, imageUrl: string, isCollapsed: boolean){
            
            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
            this.address = address;
            this.base64Image = imageUrl;
            this.isCollapsed = isCollapsed;
        }
}