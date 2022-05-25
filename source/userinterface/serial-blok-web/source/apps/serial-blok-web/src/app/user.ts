export class User {
  public oid: string;
  public firstname: string;
  public lastname: string;
  public emailAddress: string;
  public phone: string;
  public active: boolean;
  public isUser: boolean;
  public created: string;
  public createdBy: string;
  public canBeInvited: boolean;
  public name: string;

  public constructor(assignFrom?: User) {
    if (assignFrom) {
      Object.assign(this, assignFrom);
    } else {
      this.active = true;
      this.isUser = true;
    }
  }

  public get displayName(): string {
    return this.emailAddress;
  }

  public get fullNameAndEmail(): string {
    return `${this.name} (${this.emailAddress})`;
  }

  public static isValid(user: User): boolean {
    return user.emailAddress && user.emailAddress.length > 0;
  }
}
