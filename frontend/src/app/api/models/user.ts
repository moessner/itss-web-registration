export class User {

    id: string;
    firstName: string;
    lastName: string;
    address: string;
    group: string;
    authorizationCode: string;
    base64Image: string;
    isCollapsed: boolean;

    constructor(id: string, firstName: string, lastName: string,
        address: string, imageUrl: string, isCollapsed: boolean, group: string, authorizationCode: string){

            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
            this.address = address;
            this.base64Image = imageUrl;
            this.isCollapsed = isCollapsed;
            this.group = group;
            this.authorizationCode = authorizationCode;
        }
}
