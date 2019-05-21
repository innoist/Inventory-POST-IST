import { Injectable } from '@angular/core';
import { Storage } from '@ionic/storage';
import { Observable } from 'rxjs/Observable';
import { Events } from 'ionic-angular/util/events';
import { ToastService } from './toast-service';
import { TranslateService } from '@ngx-translate/core';

@Injectable()
export class CartService {
    itemAddedToCartSuccessMessage: string;
    constructor(private storage: Storage, private events: Events, private toastService: ToastService,
        translateService: TranslateService) {
        translateService.get("ITEM_ADDED_TO_CART").subscribe((value: any) => {
            this.itemAddedToCartSuccessMessage = value;
        });
    }

    addToCart(product: any) {
        this.storage.get("cart").then(cart => {
            if (!cart) {
                var _cart = { "items": [this.mapItemForCart(product)] };
                this.itemAddedHandler(_cart);
            }
            else {
                this.getProductById(product.ProductId).subscribe(value => {
                    if (!value) {
                        cart.items.push(this.mapItemForCart(product));
                    }
                    else {
                        if (value.index >= 0) {
                            ++cart.items[value.index].Quantity;
                        }
                    }
                    this.itemAddedHandler(cart);
                });
            }
        });
    }

    mapItemForCart(product: any) {
        return {
            ProductId: product.ProductId,
            Name: product.Name,
            PurchasePrice: product.PurchasePrice,
            SalePrice: product.SalePrice,
            MinSalePriceAllowed: product.MinSalePriceAllowed,
            Quantity: product.Quantity || 1,
            ImagePath: product.ProductImages != null && product.ProductImages.length > 0 ?
                product.ProductImages[0].ItemImagePath : ""
        };
    }

    itemAddedHandler(cart: any) {
        this.storage.set("cart", cart);
        this.toastService.presentToast(this.itemAddedToCartSuccessMessage);
        setTimeout(() => {
            this.events.publish("item_added_to_cart");
        }, 1000);
    }

    removeFromCart(product: any) {
        this.storage.get("cart").then(cart => {
            if (!cart.items) {
                return;
            }

            var cartItem = cart.items[cart.items.indexOf(product)];
            if (cartItem != null) {
                --cartItem.Quantity;
                this.storage.set("cart", cart);
            }
        });
    }

    getProductById(productId: any): Observable<any> {
        return Observable.fromPromise(this.storage.get("cart").then(cart => {
            var product = cart.items.filter((item: any) => {
                return item.ProductId === productId;
            });
            if (product && product.length > 0) {
                return { item: product[0], index: cart.items.indexOf(product[0]) };
            }
            return null;
        }));
    }

    getItemsCountInCart(): Observable<any> {
        var count = 0;
        return Observable.fromPromise(this.storage.get("cart").then(cart => {
            if (!cart || !cart.items) {
                return count;
            }

            cart.items.forEach((item: any) => {
                count += item.Quantity;
            });

            return count;
        }));
    }

    getItemsInCart(): Observable<any> {
        return Observable.fromPromise(this.storage.get("cart").then(cart => {
            if (!cart || !cart.items) {
                return [];
            }

            return cart.items;
        }));
    }

    reset() {
        this.storage.set("cart", "");
    }

    mapToOrder() {
        return new Promise(resolve => {
            this.getItemsInCart().subscribe(items => {
                resolve({ IsOnline: true, IsOpen: true, OrderItems: items });
            });
        });
    }
}